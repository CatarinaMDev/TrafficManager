using UnityEngine;

public enum DirectionRail
{
    left,
    right,
    up,
    down
}


public class Rail : MonoBehaviour
{
    [SerializeField] public DirectionRail direction;
    public Transform spawnPoint;
    public WarningLight warningLight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public Vector3 getDirection()
    {
        switch (direction)
        {
            case DirectionRail.left:
                return Vector3.left;
            case DirectionRail.right:
                return Vector3.right;
            case DirectionRail.up:
                return Vector3.up;
            default:
                return Vector3.down;
        }
    }
}
