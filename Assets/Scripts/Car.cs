
using UnityEngine;

// Repara: Herda de Vehicle e NÃO de MonoBehaviour
public class Car : Vehicle
{
    private bool isAtRedLight = true;
    private TrafficLight trafficLight;
    private bool hasPassedStopLine = false;

    private bool isGonnaChangeRoad = false;
    private bool hasRoad = false;

    public Vector3 myWay;

    void Update() {
  
        if (trafficLight != null)
        {
            if (isUrgent || !trafficLight.isRed || hasPassedStopLine)
            {
                base.Move(myWay);
            }
            else
            {
                base.StopMovement(myWay);
            }
        }
        else
        {
            base.Move(myWay);
        }
    }

    // Código específico do Carro para bater (Hit)
    void OnTriggerEnter2D(Collider2D collision) //falta pararem antes da linha ou seja avancam o maximo possivel ate a linha ou outro carro parado na mm estrada
    {
        base.OnTriggerEnter2D(collision);

        if (collision.gameObject.tag == "StopLine")
        {
            hasPassedStopLine = true;

        }else if(collision.gameObject.tag == "Road" && !hasRoad)
        {
            trafficLight = collision.GetComponent<Road>().myTrafficLight;
            myWay = collision.GetComponent<Road>().getDirection();
            hasRoad = true; //Falta a parte de mudar de estrada
        }
    }
    


}