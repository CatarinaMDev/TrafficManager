using UnityEngine;
using TMPro;
// Repara: Herda de Vehicle e NÃO de MonoBehaviour
public class UrgencyCar : Car
{

    [SerializeField] GameObject Light1;
    [SerializeField] GameObject Light2;
    [SerializeField] TextMeshPro textClicks;
    public GameObject NrsClicks;
    bool hasPassed = false;
    
    SpriteRenderer L1Sprite;
    SpriteRenderer L2Sprite;
    
    int nrClicksMax;

    void OnEnable()
    {
        TrafficLight.trafficLightClicked += Clicking;
    }

    
    void OnDisable()
    {
        TrafficLight.trafficLightClicked -= Clicking;
    }

    void Start(){
        var random = new System.Random();
        nrClicksMax = random.Next(4, 11);
        textClicks.text = nrClicksMax.ToString();
        NrsClicks.SetActive(true);

        L1Sprite = Light1.GetComponent<SpriteRenderer>();
        L2Sprite = Light2.GetComponent<SpriteRenderer>();

        InvokeRepeating("ChangeColor", 0f, 0.5f);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Car Hit");
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if(collision.gameObject.CompareTag("StopLine")){
            if (NrsClicks != null)
            {
                hasPassed = true;
                NrsClicks.SetActive(false);
            }
        }
    }

    void ChangeColor(){
        Color colorChange = L1Sprite.color;
        L1Sprite.color = L2Sprite.color;
        L2Sprite.color = colorChange;
    }

    private void Clicking() {
        nrClicksMax--;
        textClicks.text = nrClicksMax.ToString();
        if (nrClicksMax < 3)
        {
            textClicks.color = Color.red;
        }
        if (nrClicksMax == 0 && !hasPassed)
        {
            base.zeroClicks=true;
            NrsClicks.SetActive(false);
        }
    }



}

