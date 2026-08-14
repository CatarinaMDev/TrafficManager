
using UnityEngine;

// Repara: Herda de Vehicle e NÃO de MonoBehaviour
public class Car : Vehicle
{
    private bool isAtRedLight = true;
    private TrafficLight trafficLight;
    private bool hasPassedStopLine = false;



    void Update() {
  
        if (trafficLight != null)
        {
            if (isUrgent || !trafficLight.isRed || hasPassedStopLine)
            {
                base.Move();
            }
            else
            {
                base.StopMovement();
            }
        }
        else
        {
            Debug.Log("AINDFA N TENHO SEMAFORO" + this.tag);
            base.Move();
        }
    }

    // Código específico do Carro para bater (Hit)
    void OnTriggerEnter2D(Collider2D collision)
    {

        base.OnTriggerEnter2D(collision);

        if (collision.gameObject.tag == "StopLine")
        {
            Debug.Log("Passed Line!");
            hasPassedStopLine = true;

        }else if(collision.gameObject.tag == "Road")
        {
            Debug.Log("ESTOU NA ESTRADA e TENHO O SEMAFORO " + collision.GetComponent<Road>().myTrafficLight + "EU SOU " + this.name);
            trafficLight = collision.GetComponent<Road>().myTrafficLight;
        }
    }


}