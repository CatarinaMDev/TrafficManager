using UnityEngine;
using UnityEngine.SceneManagement; // Obrigatório para lidar com Cenas!

public class LevelManager : MonoBehaviour
{
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

    void Start()
    {
        // Descobre automaticamente em que nível estamos através do Build Index -> Usa a scene
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

        InvokeRepeating("AddCar", 0f, 5f);//dps falta pensar em evocar o train e o boat
        totalCarsNeeded = nivelAtual + 5;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void AddCar()
    {
        //dps falta pensar nas probabilisticas entre carro normal (dps carro > truck) > e urgenci (dps police>ambulance)
        int spawnRoad = Random.Range(0, roads.Length);
        Vector3 posEstrada = roads[spawnRoad].transform.position;
        
        Instantiate(carPrefab, new Vector3(-9.34f, posEstrada.y, posEstrada.z), Quaternion.identity);
    }
}
