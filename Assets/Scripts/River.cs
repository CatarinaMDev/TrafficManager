using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public enum DirectionRiver
{
    horizontal, vertical
}


public class River : MonoBehaviour
{
    [SerializeField] public DirectionRiver direction;
    public List<Transform> spawnPoints = new List<Transform>();

    void Start()
    {

        foreach (Transform child in transform)
        {
            if (child.name == "spawn_pos")
            {
                spawnPoints.Add(child);
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Vector3 getDirection(Vector3 position)
    {
        if (direction.Equals(DirectionRiver.horizontal))
        {
            if (position.x < 0f)
            {
                return Vector3.right;
            }
            return Vector3.left;
        }
        else
        {
            if (position.y < 0f)
            {
                return Vector3.up;
            }
            return Vector3.down;
        }
    }




}
