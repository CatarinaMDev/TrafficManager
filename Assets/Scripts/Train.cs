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
        if (!collision.gameObject.GetComponent<Train>() && hasRail)
        {
            base.OnTriggerEnter2D(collision);
        }

        if (collision.gameObject.CompareTag("Rail") && !hasRail)
        {
            myPlatform = collision.gameObject;
            myWay = collision.GetComponent<Rail>().getDirection();
            LookTo(myWay);
            hasRail = true; //Falta a parte de mudar de estrada
        }
    }

    public override void CollideWithOtherVehicle()
    {

        hasRail = false;


        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {

            // 3. Muda para Dynamic para a física tomar conta dele
            rb.bodyType = RigidbodyType2D.Dynamic;

            // 4. (MUITO IMPORTANTE) Como é Top-Down, a gravidade tem de ser 0 senão ele cai para fora do ecrã!
            rb.gravityScale = 0f;

            // 5. Calcula uma direção aleatória para ele ser atirado
            // Atiramos um bocadinho para trás (-myWay) e um bocadinho para os lados (Random)
            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            Vector2 impactForce = (-(Vector2)myWay + randomDirection).normalized;

            // 6. Aplica a Força (Pancada)! O '15f' é a força, podes aumentar se quiseres que voe mais longe
            rb.AddForce(impactForce, ForceMode2D.Impulse);

            // 7. Aplica a Rotação (Derrapagem)! O comboio vai girar descontrolado
            rb.AddTorque(Random.Range(-5f,5f), ForceMode2D.Impulse);
        }
    }

}
