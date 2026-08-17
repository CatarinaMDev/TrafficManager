
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
                        if (hit.collider.tag == "Vehicle")
                        {
                        Debug.Log("Eu: "+ this.name+ " + Paro por causa da viatura:"+hit.collider.name);
                        base.StopMovement(myWay);
                        }
                        else if (hit.collider.tag == "StopLine" && !isUrgent &&  trafficLight.isRed)
                        {
                        Debug.Log("Eu: " + this.name+"Paro por causa da linha");
                        base.StopMovement(myWay);
                        }
                        else
                        {
                        Debug.Log("Eu: " + this.name + "N paro pq n era viatura nem linha");
                            base.Move(myWay);
                        }
                    }
                    else
                    {
                    Debug.Log("Eu: " + this.name + "N paro pq n detetei");
                        base.Move(myWay);
                    }
                }
                else
                {
                Debug.Log(" paro pq n tenho estrada");
                    base.StopMovement(myWay);
                }

    
        }
    }

    // Código específico do Carro para bater (Hit)
    void OnTriggerEnter2D(Collider2D collision) 
    {
        base.OnTriggerEnter2D(collision);

        if(collision.gameObject.tag == "Road" && !hasRoad)
        {
            trafficLight = collision.GetComponent<Road>().myTrafficLight;
            myWay = collision.GetComponent<Road>().getDirection();

         /**   switch(myWay)
            {
                case Vector3.left:
                    transform.rotation.y =    -180f;
                    break;
                case Vector3.right:
                    transform.rotation.y = 0f;
                    break;
                case Vector3.up:
                    transform.rotation.z = 90f;
                    break;
                case Vector3.down:
                    transform.rotation.y = -90f;
                    break;
            }
         **/
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