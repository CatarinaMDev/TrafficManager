
using UnityEngine;

// Repara: Herda de Vehicle e NÃO de MonoBehaviour
public class Car : Vehicle
{
    public LayerMask raycastSees;
    private TrafficLight trafficLight;
    bool isStoppedAtRedLight = false;
    private bool isGonnaChangeRoad = false;
    private bool hasRoad = false;
    private float distance = 0.2f;

    public Vector3 myWay;

    void Update()
    {

        if (trafficLight != null)
        {
            if (hasRoad)
            {
                    Debug.DrawRay(transform.position + (myWay * 0.3f), myWay * distance, Color.pink);
                    RaycastHit2D hit = Physics2D.Raycast(transform.position + (myWay * 0.3f), myWay, distance, raycastSees);
                    if (hit.collider != null)
                    {
                        
                        Debug.Log("VI: " + hit.collider.tag + "E urgente?" + isUrgent + " Traffic Light is red? " + trafficLight.isRed);
                        if (hit.collider.tag == "Vehicle")
                        {
                            Debug.Log("VI: " + hit.collider.tag);
                            base.StopMovement(myWay);
                        }
                        else if (hit.collider.tag == "StopLine" && !isUrgent && trafficLight.isRed)
                        {
                            Debug.Log("VI: " + hit.collider.tag);
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
            Debug.Log("EUSOU:" + this.gameObject.name );
            trafficLight = collision.GetComponent<Road>().myTrafficLight;
            myWay = collision.GetComponent<Road>().getDirection();
            hasRoad = true; //Falta a parte de mudar de estrada
        }
    }
    


}