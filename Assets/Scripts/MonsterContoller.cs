
using UnityEngine;

public class MonsterContoller : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private Transform markerL;
    [SerializeField] private Transform markerR;
    [SerializeField] private int lives = 1;
    private Rigidbody2D rb;
    private Animator anim;
  
    private bool isRight = true;
   
    private SpriteRenderer sprite;
    private bool isTurn = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        // lifeUI = GetComponent<LifeUI>();
    }

    private void Update()
    {

        if (isRight && transform.position.x > markerR.position.x)
        {
            isRight = false;
            sprite.flipX = true;

        }
        else if (!isRight && transform.position.x < markerL.position.x)
        {
            isRight = true;
            sprite.flipX = false;
        }

        if (isRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            lives -= 1;
            if(lives <= 0)
            {
                anim.SetTrigger("dead");
                Destroy(this);
                Destroy(GetComponent<Collider2D>());
                Destroy(rb);
                Destroy(transform.parent.gameObject);
            }

        }
     
    }




}
