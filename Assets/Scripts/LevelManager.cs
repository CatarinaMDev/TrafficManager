using UnityEngine;
using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement; // Obrigatório para lidar com Cenas!

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private int currentLevel;

    private GameObject[] roads;
    private GameObject[] rivers;
    private GameObject[] rails;

    public GameObject[] roadVehicles;
    public GameObject trainPrefab;
    public GameObject boatPrefab;

    public int totalCarsNeeded;
    public int totalCarsPassed;

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
        level_Text.text = currentLevel.ToString();
        Debug.Log("Welcome to level " + currentLevel);
            
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
        totalCarsNeeded = (currentLevel* currentLevel)*2 + 8;
        carsInfo_Text.text = totalCarsPassed + "/" + totalCarsNeeded;
        if (rails.Length > 0)
            InvokeRepeating("AddTrain", 0f, 10f);
        if (rivers.Length > 0)
            InvokeRepeating("AddBoat", 0f, 10f);
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
        GameObject roadPrefab = roadVehicles[Random.Range(0, roadVehicles.Length)];//mudar a probabilistica entre carro normal (dps carro > truck) > e urgenci (dps police>ambulance)
        GameObject roadChosen = roads[Random.Range(0, roads.Length)];

        Vector3 position = roadChosen.GetComponent<Road>().spawnPoint.position;
        Instantiate(roadPrefab, new Vector3(position.x, position.y,position.z), Quaternion.identity);
    }
    void AddTrain()
    {
        StartCoroutine(SpawnTrainRoutine());
    }

    private IEnumerator SpawnTrainRoutine()
    {

        GameObject railChosen = rails[Random.Range(0, rails.Length)]; 
        Rail railComponent = railChosen.GetComponent<Rail>();

        railComponent.warningLight.Light();
        AudioManager.instance.PlaySFX(AudioManager.instance.train_warning);
        yield return new WaitForSeconds(4f);

        Vector3 position = railComponent.spawnPoint.position;
        Instantiate(trainPrefab, new Vector3(position.x, position.y, position.z), Quaternion.identity);
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
        carsInfo_Text.text = totalCarsPassed + "/" + totalCarsNeeded;
        if (totalCarsPassed == totalCarsNeeded)
        {
            GameManager.instance.LevelCompleted();
        }
    }

    public string getFinalTime()
    {
        return time_Text.text;
    }
}
