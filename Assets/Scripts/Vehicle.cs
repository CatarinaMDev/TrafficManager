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


    protected virtual void StopMovement(Vector3 direction)
    {
        transform.Translate(direction * Time.deltaTime * 0f);
       
        

    }

    protected virtual void Move(Vector3 direction)
    {
        this.transform.Translate(direction * speed * Time.deltaTime);
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObj = collision.gameObject;
        if (otherObj.tag == "Vehicle") {
            Debug.Log("Collision!");
            GameManager.instance.GameOver();
        }

    }

    protected virtual void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    


}

