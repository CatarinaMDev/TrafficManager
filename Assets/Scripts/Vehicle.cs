using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{

    public float speed;
    public Color color;
    public string direction;//(1-> horizontal 2-> vertical)
    public string way; //(1-> down, 2-> up // 1- > left 2-> right)

    public bool isUrgent = false;
    public bool isRoadVehicle = true;
    public bool isInRedLight = true;

    public Vector3 vectorWay;

    public GameObject baseObject;
    public SpriteRenderer baseSprite;

    // Usamos protected virtual para que as classes filhas possam sobrescrever se precisarem
    protected virtual void Start()
    {
        
        baseSprite.color = this.color;

    }


    protected virtual void StopMovement()
    {
        transform.Translate(Vector3.right * Time.deltaTime * 0f);
    }

    protected virtual void Move()
    {
        this.transform.Translate(Vector3.right * speed * Time.deltaTime);
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

