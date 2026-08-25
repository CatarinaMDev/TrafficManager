
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
        if (hasRoad) { 
        base.OnTriggerEnter2D(collision);
        }

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


    public override void CollideWithOtherVehicle()
    {

        hasRoad = false;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // 3. Muda para Dynamic para a física tomar conta dele
            rb.bodyType = RigidbodyType2D.Dynamic;

            // 4. (MUITO IMPORTANTE) Como é Top-Down, a gravidade tem de ser 0 senão ele cai para fora do ecrã!
            rb.gravityScale = 0f;

            // 5. Calcula uma direção aleatória para ele ser atirado
            // Atiramos um bocadinho para trás (-myWay) e um bocadinho para os lados (Random)
            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            Vector2 impactForce = (-(Vector2)myWay + randomDirection).normalized;

           
            rb.AddForce(impactForce, ForceMode2D.Impulse);

            // Rotation 
            rb.AddTorque(Random.Range(-5f, 5), ForceMode2D.Impulse);
        }
    }

}