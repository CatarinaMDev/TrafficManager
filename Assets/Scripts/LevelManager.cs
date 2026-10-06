using UnityEngine;
using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement; // Obrigatório para lidar com Cenas!

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private float currentLevel;

    private GameObject[] roads;
    private GameObject[] rivers;
    private GameObject[] rails;

    public GameObject[] roadVehicles;
    public GameObject trainPrefab;
    public GameObject boatPrefab;

    public float totalCarsNeeded;
    public float totalCarsPassed;

    [SerializeField] TextMeshProUGUI carsInfo_Text;
    [SerializeField] TextMeshProUGUI time_Text;
    [SerializeField] TextMeshProUGUI level_Text;

    float elapsedTime;


    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        
        totalCarsPassed = 0;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        totalCarsNeeded = (currentLevel * currentLevel) * 2 + 8;

        if(currentLevel == 5)
        {

            level_Text.text = "∞"; 
            carsInfo_Text.text = totalCarsPassed + " /∞";
        }
        else
        {

            level_Text.text = currentLevel.ToString();
            carsInfo_Text.text = totalCarsPassed + "/" + totalCarsNeeded;
        }

        if (roads == null)
            roads = GameObject.FindGameObjectsWithTag("Road");
        Debug.Log("Estradas detetadas automaticamente: " + roads.Length);

        if (rivers == null)
            rivers = GameObject.FindGameObjectsWithTag("River");
        Debug.Log("Rios detetados automaticamente: " + rivers.Length);

        if (rails == null)
            rails = GameObject.FindGameObjectsWithTag("Rail");
        Debug.Log("Caminhos de Ferro detetados automaticamente: " + rails.Length);

        if (roads.Length > 0)
            InvokeRepeating("AddRoadVehicle", 0f, 2f);

        float timeVehicle = (12 - currentLevel);
        if (rails.Length > 0)
            InvokeRepeating("AddTrain", 0f, timeVehicle);

        timeVehicle = (8 - currentLevel);
        if (rivers.Length > 0)
            InvokeRepeating("AddBoat", 0f, timeVehicle);
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;  
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        time_Text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void AddRoadVehicle()
    {

        int nrCars = Random.Range(2, roads.Length);

        
        List<GameObject> availableRoads = new List<GameObject>(roads);

        for (int i = 0; i < nrCars; i++){
            if (availableRoads.Count == 0) break;

            int randomRoadIndex = Random.Range(0, availableRoads.Count);
            GameObject roadChosen = availableRoads[randomRoadIndex];
            availableRoads.RemoveAt(randomRoadIndex);

            int chance = Random.Range(0, 100);
            GameObject prefabToSpawn;

            if (chance < 60){
                // 60% Car 
                prefabToSpawn = roadVehicles[0];
            }else if (chance < 85){
                // 25% Truck
                prefabToSpawn = roadVehicles[1];
            } else if (chance < 95){
                // 10% Police 
                prefabToSpawn = roadVehicles[2];
            }else{
                // 5% Ambulance
                prefabToSpawn = roadVehicles[3];
            }

            Vector3 position = roadChosen.GetComponent<Road>().spawnPoint.position;
            Instantiate(prefabToSpawn, position, Quaternion.identity);
        }
    }

    void AddTrain()
    {
        StartCoroutine(SpawnTrainRoutine());
    }

    private IEnumerator SpawnTrainRoutine()
    {
        int nrTrains = Random.Range(1, rails.Length);
        List<GameObject> availableRails = new List<GameObject>(rails);
        List<GameObject> chosenRails = new List<GameObject>();

        for (int i = 0; i < nrTrains; i++)
        {
            int randomIndex = Random.Range(0, availableRails.Count);
            chosenRails.Add(availableRails[randomIndex]);
            availableRails.RemoveAt(randomIndex);
        }

        
        foreach (GameObject rail_chosen in chosenRails)
        {
            Rail railComponent = rail_chosen.GetComponent<Rail>();
            railComponent.warningLight.Light();
        }

        AudioManager.instance.PlaySFX(AudioManager.instance.train_warning);
        yield return new WaitForSeconds(4f);

        foreach (GameObject rail_chosen in chosenRails)
        {
            Rail railComponent = rail_chosen.GetComponent<Rail>();
            Vector3 position = railComponent.spawnPoint.position;
            Instantiate(trainPrefab, position, Quaternion.identity);
        }

        AudioManager.instance.PlaySFX(AudioManager.instance.train_passing);

    }

 
    void AddBoat()
    {
        GameObject riverChosen = rivers[Random.Range(0, rivers.Length)];


        Transform spawnPoint = riverChosen.GetComponent<River>().spawnPoints[Random.Range(0, riverChosen.GetComponent<River>().spawnPoints.Count)];
        Vector3 position = spawnPoint.position;
        Instantiate(boatPrefab, new Vector3(position.x, position.y, position.z), Quaternion.identity);

    }


    public void AddPoints()
    {
        totalCarsPassed++;
        if (currentLevel != 5 && currentLevel != 0 )
        {
            carsInfo_Text.text = totalCarsPassed + "/" + totalCarsNeeded;
            if (totalCarsPassed == totalCarsNeeded)
            {
                GameManager.instance.LevelCompleted();
            }
        }
        else
        {
            carsInfo_Text.text = totalCarsPassed + "/∞";
        }
        
        
    }

    public string getFinalTime()
    {
        return time_Text.text;
    }
    public float getCarsSucceded()
    {
        return totalCarsPassed;
    }
}
