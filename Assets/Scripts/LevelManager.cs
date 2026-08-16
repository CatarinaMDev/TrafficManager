using UnityEngine;
using UnityEngine.SceneManagement; // Obrigatório para lidar com Cenas!

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private int nivelAtual;

    public GameObject road_vehicles;
    public GameObject river_vehicles;
    public GameObject rail_vehicles;

    private GameObject[] roads;
    private GameObject[] rivers;
    private GameObject[] rails;

    public GameObject carPrefab;
    public GameObject truckPrefab;
    public GameObject ambulancePrefab;
    public GameObject policePrefab;
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


        InvokeRepeating("AddCar", 0f, 2f);//dps falta pensar em evocar o train e o boat
        totalCarsNeeded = nivelAtual + 5;//ver a matematica q vou usar

    }

    void AddCar()
    {
        //dps falta pensar nas probabilisticas entre carro normal (dps carro > truck) > e urgenci (dps police>ambulance)
        int spawnRoad = Random.Range(0, roads.Length);
        Vector3 posEstrada = roads[spawnRoad].transform.position;
        Debug.Log("ESTRADA NR: "+ spawnRoad  + "POS ESTRADA: " + posEstrada);
        
        Instantiate(carPrefab, new Vector3(-9.34f, posEstrada.y, posEstrada.z), Quaternion.identity);
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
