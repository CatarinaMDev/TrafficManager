using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{

    public float speed;
    public Color color;
    public string direction;//(1-> horizontal 2-> vertical)
    public string way; //(1-> down, 2-> up // 1- > left 2-> right)

    public bool isUrgent;
    public bool isRoadVehicle;
    public bool isInRedLight;

    public GameObject baseObject;
    public SpriteRenderer baseSprite;

    // Usamos protected virtual para que as classes filhas possam sobrescrever se precisarem
    protected virtual void Start()
    {
        
        baseSprite.color = this.color;
    }


    protected virtual void StopMovement(Vector3 direction)
    {
        transform.Translate(direction * Time.deltaTime * 0f);
        Debug.Log("EU:" + this.gameObject.name + "PAREI");
        

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
        } 

    }

    protected virtual void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }


}

