
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
                    RaycastHit2D hit = Physics2D.Raycast(transform.position + (myWay * 0.5f), myWay, distance, raycastSees);
                    if (hit.collider != null)
                    {
                        
                        if (hit.collider.tag == "Vehicle")
                        {
                            
                            base.StopMovement(myWay);
                        }
                        else if (hit.collider.tag == "StopLine" && !isUrgent && trafficLight.isRed)
                        {
                           
                            base.StopMovement(myWay);
                        }
                        else
                        {
                            base.Move(myWay);
                        }
                    }
                    else
                    {
                        base.Move(myWay);
                    }
                }
                else
                {
                    base.Move(myWay);
                }

    
        }
    }

    // Código específico do Carro para bater (Hit)
    void OnTriggerEnter2D(Collider2D collision) //falta pararem antes da linha ou seja avancam o maximo possivel ate a linha ou outro carro parado na mm estrada
    {
        base.OnTriggerEnter2D(collision);

        if(collision.gameObject.tag == "Road" && !hasRoad)
        {
            
            trafficLight = collision.GetComponent<Road>().myTrafficLight;
            myWay = collision.GetComponent<Road>().getDirection();
            hasRoad = true; //Falta a parte de mudar de estrada
        }
        else if (collision.gameObject.tag == "Checkmark")
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