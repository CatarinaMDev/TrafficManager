using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{

    public float speed;
    private Color color;
    public string direction;//(1-> horizontal 2-> vertical)
    public string way; //(1-> down, 2-> up // 1- > left 2-> right)

    
    public bool isUrgent;
    public bool isRoadVehicle;
    public bool isInRedLight;

    public GameObject baseObject;
    public SpriteRenderer baseSprite;

    public Color[] colors;

    public GameObject myPlatform;

    // Usamos protected virtual para que as classes filhas possam sobrescrever se precisarem
    protected virtual void Start()
    {
        if (colors.Length > 0)

        {
            this.color = colors[Random.Range(0, colors.Length)];
            Debug.Log("New Color:" + color);
            baseSprite.color = this.color;
        }
        else
        {
            baseSprite.color = Color.white;
        }

       
    }


    protected virtual void StopMovement()
    {
        Vector3 direction = new Vector3(1f, 0f, 0f);
        transform.Translate(direction * Time.deltaTime * 0f);
       
        

    }

    protected virtual void Move()
    {
        Vector3 direction = new Vector3(1f, 0f, 0f);
        Debug.Log("Moving "+ this.name + ":" + direction);
        Debug.Log("Moving:" + Vector3.right);
        this.transform.Translate(direction * speed * Time.deltaTime);
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Vehicle") {
            Debug.Log("Collision!");
            GameManager.instance.GameOver();
        }

    }

    protected virtual void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    protected virtual void LookTo(Vector3 direction)
    {

        if (direction == Vector3.left)
        {
            // Roda 180 graus no eixo Y (Efeito espelho / virar para a esquerda)
            transform.eulerAngles = new Vector3(0f, -180f, 0f);
        }
        else if (direction == Vector3.right)
        {
            // Volta à rotação original
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (direction == Vector3.up)
        {
            // Roda 90 graus no eixo Z (Aponta para cima em jogos 2D)
            transform.eulerAngles = new Vector3(0f, 0f, 90f);
        }
        else if (direction == Vector3.down)
        {
            // Roda -90 graus no eixo Z (Aponta para baixo)
            transform.eulerAngles = new Vector3(0f, 0f, -90f);
        }
    }


}

