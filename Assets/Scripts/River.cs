using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public enum DirectionRiver
{
    left,
    right,
    up,
    down
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


    public Vector3 getDirection()
    {
        switch (direction)
        {
            case DirectionRiver.left:
                return Vector3.left;
            case DirectionRiver.right:
                return Vector3.right;
            case DirectionRiver.up:
                return Vector3.up;
            default:
                return Vector3.down;
        }
    }



    }
