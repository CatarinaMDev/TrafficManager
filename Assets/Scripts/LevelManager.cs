using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Obrigatório para lidar com Cenas!

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private int nivelAtual;

    private GameObject[] roads;
    private GameObject[] rivers;
    private GameObject[] rails;

    public GameObject[] roadVehicles;
    public GameObject trainPrefab;
    public GameObject boatPrefab;

    public int totalCarsNeeded;
    public int totalCarsPassed;
    


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
        nivelAtual = SceneManager.GetActiveScene().buildIndex;

        Debug.Log("Bem-vindo ao Nível " + nivelAtual);
            
        if (roads == null)
            roads = GameObject.FindGameObjectsWithTag("Road");
        Debug.Log("Estradas detetadas automaticamente: " + roads.Length);

        if (rivers == null)
            rivers = GameObject.FindGameObjectsWithTag("River");
        Debug.Log("Rios detetados automaticamente: " + rivers.Length);

        if (rails == null)
            rails = GameObject.FindGameObjectsWithTag("Rail");
        Debug.Log("Caminhos de Ferro detetados automaticamente: " + rails.Length);


        InvokeRepeating("AddRoadVehicle", 0f, 2f);//dps falta pensar em evocar o train e o boat
        totalCarsNeeded = nivelAtual + 5;//ver a matematica q vou usar

        InvokeRepeating("AddTrain", 0f, 10f);
        InvokeRepeating("AddBoat", 0f, 10f);
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

        yield return new WaitForSeconds(4f);

        Vector3 position = railComponent.spawnPoint.position;
        Instantiate(trainPrefab, new Vector3(position.x, position.y, position.z), Quaternion.identity);
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
        if (totalCarsPassed == totalCarsNeeded)
        {
            GameManager.instance.LevelCompleted();
        }
    }
}
