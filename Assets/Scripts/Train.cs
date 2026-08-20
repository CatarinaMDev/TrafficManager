using UnityEngine;

public class Train : Vehicle
{
    [SerializeField] GameObject baseObject1;
    [SerializeField] GameObject baseObject2;
    [SerializeField] GameObject baseObject3;
    private SpriteRenderer baseSprite1;
    private SpriteRenderer baseSprite2;
    private SpriteRenderer baseSprite3;
    public LayerMask raycastSees;
    private bool hasRail = false;
    private Vector3 myWay;
    float distance = 0.3f;
    void Start()
    {

        baseSprite1 = baseObject1.GetComponent<SpriteRenderer>();
        baseSprite2 = baseObject2.GetComponent<SpriteRenderer>();
        baseSprite3 = baseObject3.GetComponent<SpriteRenderer>();

        baseSprite1.color = colors[Random.Range(0, colors.Length)];
        baseSprite2.color = colors[Random.Range(0, colors.Length)];
        baseSprite3.color = colors[Random.Range(0, colors.Length)];
        transform.localScale = new Vector3(5.27f, 0.42f, 1.23f);
    }
    void Update()
    {
        if (hasRail) {
            Vector3 beginRaycast = transform.position + (myWay * 3f);
            Debug.DrawRay(beginRaycast, myWay * distance, Color.blue);
            RaycastHit2D hit = Physics2D.Raycast(beginRaycast, myWay, distance, raycastSees);

            if (hit.collider != null)
            {
                Debug.Log("Collider q apanhei:" + hit.collider.tag + "nome" + hit.collider.name + hit.collider.gameObject.GetComponent<Train>());

                if (hit.collider.CompareTag("Vehicle") && hit.collider.gameObject.GetComponent<Train>() != null)
                {
                    StopMovement();
                }
                else
                {
                    Move();
                }
            }
            else
            {
                Move();
            }
        }
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Rail") && !hasRail)
        {
            myPlatform = collision.gameObject;
            myWay = collision.GetComponent<Rail>().getDirection();
            LookTo(myWay);
            hasRail = true; //Falta a parte de mudar de estrada
        }
    }


}
