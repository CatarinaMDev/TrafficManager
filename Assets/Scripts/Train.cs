using UnityEngine;

public class Train : Vehicle
{
    [SerializeField] GameObject baseObject1;
    [SerializeField] GameObject baseObject2;
    [SerializeField] GameObject baseObject3;
    private SpriteRenderer baseSprite1;
    private SpriteRenderer baseSprite2;
    private SpriteRenderer baseSprite3;

    private bool hasRail = false;
    private Vector2 myWay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        if (hasRail) Move();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Rail" && !hasRail)
        {
            myPlatform = collision.gameObject;
            myWay = collision.GetComponent<Rail>().getDirection();
            LookTo(myWay);
            hasRail = true; //Falta a parte de mudar de estrada
        }
    }


}
