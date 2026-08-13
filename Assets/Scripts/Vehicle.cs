using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{

    public float speed;
    public Color color;
    public int direction;//(1-> horizontal 2-> vertical)
    public int way; //(1-> down, 2-> up // 1- > left 2-> right)
    public bool isUrgent = false;
    public bool isRoadVehicle = true;

    public GameObject baseObject;
    public SpriteRenderer baseSprite;

    // Usamos protected virtual para que as classes filhas possam sobrescrever se precisarem
    protected virtual void Start()
    {
        baseSprite.color = this.color;
    }

    public void Move()
    {
        // Movimento base comum a todos
    }
}

