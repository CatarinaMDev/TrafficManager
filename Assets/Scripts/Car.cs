
using UnityEngine;

// Repara: Herda de Vehicle e NÃO de MonoBehaviour
public class Car : Vehicle
{
    public bool isAtRedLight = true;

    void Start()
    {
        base.Start();
    }

    // Como é um MonoBehaviour (através do Vehicle), pode usar o Update!
    void Update()
    {
        if (!isAtRedLight)
        {
            Move();
        }
        else
        {
            Stop();
        }
    }

    // Código específico do Carro para bater (Hit)
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Car Hit");
    }

    void Move()
    {

    }

    void Stop()
    {
        speed = 0f;
    }
}