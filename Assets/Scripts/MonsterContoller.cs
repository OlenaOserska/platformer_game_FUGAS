
using UnityEngine;

public class MonsterContoller : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    [SerializeField] private Transform MarkerL;
    [SerializeField] private Transform MarkerR;
    private Rigidbody2D rb;
    private Animator anim;
  
    private bool isRight = true;
   
    private SpriteRenderer sprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        // lifeUI = GetComponent<LifeUI>();
    }

    private void Update()
    {
        if (transform.position.x > MarkerR.position.x)
        {
            isRight = false;
        }
        else if (transform.position.x < MarkerL.position.x)
        {

            isRight = true;

        }
        if (isRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            sprite.flipX = false;
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            sprite.flipX = true;
        }
    }
    
    

    
}
