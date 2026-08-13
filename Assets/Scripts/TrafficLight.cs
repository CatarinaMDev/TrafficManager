using UnityEngine;
using UnityEngine.EventSystems; 
public class TrafficLight : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject greenLight;
    [SerializeField] GameObject redLight;

    SpriteRenderer greenSprite;
    SpriteRenderer redSprite;

    bool isRed = true;

    void Start()
    {
        greenSprite = greenLight.GetComponent<SpriteRenderer>();
        redSprite = redLight.GetComponent<SpriteRenderer>();
        changeColor();
    }

    // 3. Esta é a versão moderna e oficial que substitui o OnMouseDown -> Da com o rato ou com o dedo
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(greenSprite.color);
        Debug.Log(redSprite.color);
        isRed = !isRed;
        changeColor();  
    }

    void changeColor()
    {
        if (isRed) {
            greenSprite.color = Color.gray; 
            redSprite.color = Color.red;
        }
        else {
            greenSprite.color = Color.green; 
            redSprite.color = Color.gray;
        }
    }
}
