using UnityEngine;

public class Train : Vehicle
{
    [SerializeField] GameObject baseObject1;
    [SerializeField] GameObject baseObject2;
    [SerializeField] GameObject baseObject3;
    private SpriteRenderer baseSprite1;
    private SpriteRenderer baseSprite2;
    private SpriteRenderer baseSprite3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        baseSprite1 = baseObject1.GetComponent<SpriteRenderer>();
        baseSprite2 = baseObject2.GetComponent<SpriteRenderer>();
        baseSprite3 = baseObject3.GetComponent<SpriteRenderer>();

        baseSprite1.color = Color.red;
        baseSprite2.color = Color.yellow;
        baseSprite3.color = Color.pink;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
