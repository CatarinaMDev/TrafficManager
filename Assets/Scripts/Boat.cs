using UnityEngine;

public class Boat : Vehicle
{
    private bool hasRiver = false;
    private Vector3 myWay;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {
        if (hasRiver) Move();

    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "River" && !hasRiver)
        {
            myPlatform = collision.gameObject;
            myWay = collision.GetComponent<River>().getDirection(transform.position);
            LookTo(myWay);
            Debug.Log("I was born in a River im positioned: " + transform.position + " I look at " + (myWay));
            hasRiver = true; //Falta a parte de mudar de estrada
        }
    }
}
