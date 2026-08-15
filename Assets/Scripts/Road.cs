using UnityEngine;

public enum Direction
{
    left,
    right,
    up,
    down
}


public class Road : MonoBehaviour
{
    [SerializeField] public TrafficLight myTrafficLight;

    public float Z; //Horizontal or Vertical > 0 or 90;
    public float Y; //posicao no mapa do Y
    public float X; //posicao no mapa do X

    [SerializeField] public Direction direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Z = this.transform.position.z;
        X = this.transform.position.x;
        Y = this.transform.position.y;

        Debug.Log("Estou no " + Z + "E a minha posicao é : X "+ X + " e Y " + Y);
    }

    public Vector3 getDirection()
    {
        switch (direction)
        {
            case Direction.left: 
                return Vector3.left;
            case Direction.right:
                return Vector3.right;
            case Direction.up:
                return Vector3.up;
            default:
                return Vector3.down;
        }
       

    }



}
