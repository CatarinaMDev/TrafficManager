using UnityEngine;



public class River : MonoBehaviour
{
    [SerializeField] public Vector3 direction;
    public Transform spawnPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        spawnPoints = transform.Find("spawn_pos");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Vector3 getDirection()
    {
        return Vector3.left;
        


    }
}
