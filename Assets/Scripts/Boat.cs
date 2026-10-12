using UnityEngine;

public class Boat : Vehicle
{
    private bool hasRiver = false;


    // Update is called once per frame
    void Update()
    {
        if (hasRiver) Move();

    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "River" && !hasRiver)
        {
            myPlatform = collision.gameObject;
            myWay = collision.GetComponent<River>().getDirection();
            LookTo(myWay);
            hasRiver = true;
        }
    }
}
