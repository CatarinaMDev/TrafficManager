using UnityEngine;
using UnityEngine.EventSystems; 
public class TrafficLight : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject greenLight;
    [SerializeField] GameObject redLight;

    SpriteRenderer greenSprite;
    SpriteRenderer redSprite;

    public bool isRed
    {
        get { return _isRed; }
        set
        {
            _isRed = value;
            changeColor(); // A magia acontece aqui: sempre que alterares o IsRed, a cor atualiza sozinha!
        }
    }

    // Variável privada real que guarda o valor (o _ no início é convenção para variáveis privadas)
    private bool _isRed = true;

    

    void Start()
    {
       
        greenSprite = greenLight.GetComponent<SpriteRenderer>();
        redSprite = redLight.GetComponent<SpriteRenderer>();
        isRed = true;
    }

    // 3. Esta é a versão moderna e oficial que substitui o OnMouseDown -> Da com o rato ou com o dedo
    public void OnPointerClick(PointerEventData eventData)
    {
        isRed = !isRed;
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
