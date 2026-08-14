using UnityEngine;

// Repara: Herda de Vehicle e NÃO de MonoBehaviour
public class UrgencyCar : MonoBehaviour
{

    [SerializeField] GameObject Light1;
    [SerializeField] GameObject Light2;

    SpriteRenderer L1Sprite;
    SpriteRenderer L2Sprite;

    void Start(){

        L1Sprite = Light1.GetComponent<SpriteRenderer>();
        L2Sprite = Light2.GetComponent<SpriteRenderer>();

        InvokeRepeating("ChangeColor", 0f, 0.5f);

    }


    // Código específico do Carro para bater (Hit)
    void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("Car Hit");
    }

    void ChangeColor(){
        Color colorChange = L1Sprite.color;
        L1Sprite.color = L2Sprite.color;
        L2Sprite.color = colorChange;
    }

}

