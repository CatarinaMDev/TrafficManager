
using UnityEngine;

// Repara: Herda de Vehicle e NÃO de MonoBehaviour
public class Car : Vehicle
{
    public LayerMask raycastSees;
    private TrafficLight trafficLight;
    bool isStoppedAtRedLight = false;
    private bool isGonnaChangeRoad = false;
    private bool hasRoad = false;
    private float distance = 0.1f;
    private Vector3 myWay;

    public GameObject check;
    void Awake()
    {
        if (check != null)
        {
            check.SetActive(false);
        }
        
    }

    void Update()
    {

        if (trafficLight != null)
        {
            if (hasRoad)
            {

                    Debug.DrawRay(transform.position + (myWay * 0.5f), myWay * distance, Color.pink);
                    RaycastHit2D hit = Physics2D.Raycast(transform.position + (myWay * 0.5f), myWay, distance , raycastSees);
                    if (hit.collider != null)
                    {
                    Debug.Log("Collider q apanhei:" + hit.collider.tag);
                        if ((hit.collider.CompareTag("Vehicle") && this.myPlatform==hit.collider.gameObject.GetComponent<Vehicle>().myPlatform)
                            ||(hit.collider.tag == "StopLine" && !isUrgent && trafficLight.isRed))
                        {
                            StopMovement();
                        }
                        else
                        {
                            Move();
                        }
                    }
                    else
                    {
                        Move();
                    }
                }
                else
                {
                    StopMovement();
                }

    
        }
    }

    // Código específico do Carro para bater (Hit)
    void OnTriggerEnter2D(Collider2D collision) 
    {
        base.OnTriggerEnter2D(collision);


        if (collision.gameObject.CompareTag("Road") && !hasRoad)
        {
            myPlatform = collision.gameObject;
            trafficLight = collision.GetComponent<Road>().myTrafficLight;
            myWay = collision.GetComponent<Road>().getDirection();
            LookTo(myWay);
            hasRoad = true; //Falta a parte de mudar de estrada
        }
        else if (collision.gameObject.CompareTag("Checkmark"))
        {
            showCheck();
            LevelManager.instance.AddPoints();
        }

    }

    void showCheck()
    {
        if (check != null)
        {
            check.SetActive(true);
        }
    }


}