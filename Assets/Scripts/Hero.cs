using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private int lives = 3;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private int coins;
  //  [SerializeField] private TextMeshProUGUI textMoney;
  //  [SerializeField] private LifeUI lifeUI;
 //   [SerializeField] private Rigidbody2D apple;
  //  [SerializeField] private TextMeshProUGUI textApple;

   
    private bool isRight = true;
    private bool isGrounded = false;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
   // private int goldCount = 0;
   // private int appleCount = 0;
    private Rigidbody2D tempApple;
    private bool IsControl = true;
    private float move;

    public static object Intance { get; internal set; }

    private int hearts = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coins")
        {
            coins += 100 ;
          //  goldCount += 100;
          //  textMoney.text = goldCount.ToString();

            Destroy(collision.gameObject);
        }
       /* if (collision.tag == "checkpoint")
        {
            PlayerPrefs.SetFloat("xPos", transform.position.x);
            PlayerPrefs.SetFloat("yPos", transform.position.y);
        }*/
        /* else if (collision.tag == "Floor")
         {
             Damage();
         }
         if (lives == 0)
         {
            // var currSceneIndex = SceneManager.GetActiveScene().buildIndex;
             SceneManager.LoadScene(0);
         }
         else if (collision.tag == "Slime")
         {
            // lives -= 1;
            // lifeUI.RemoveHeart();
             Damage();
         }
         if (collision.tag == "Apple")
             {

                 appleCount += 1;
                 textApple.text = appleCount.ToString();

                 print("Apple: " + appleCount);
                 Destroy(collision.gameObject);
             }

     }*/
        /* private void OnCollisionEnter2D(Collision2D collision)
         {
             if (collision.transform.tag == "Saw")
             {
                 //lives -= 1;
                // lifeUI.RemoveHeart();
                 Damage();
                 print("Saw: " + collision.GetContact(0).point);
                 StartCoroutine(StopControl());
             }
             else if (collision.gameObject.tag == "monster")
             {
                // lives -= 1;
                // lifeUI.RemoveHeart();
                 Damage();
             }
        */
    }
    IEnumerator StopControl()
    {
        IsControl = false;
        yield return new WaitForSeconds(1);
        IsControl= true;
    }
     private void Damage()
     {
          lives--;
        // lifeUI.RemoveHeart();
         if (lives <= 0)
         {
             Time.timeScale = 0;
           //  lifeUI.GameOver();
         }
     }
   /* private void Start()
    {
        transform.position = new Vector2(PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos"));
    }*/

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        // lifeUI = FindObjectOfType<LifeUI>();
       // transform.position = new Vector2(PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos"));
    }

    private void FixedUpdate()
    {
        move = Input.GetAxis("Horizontal");
        CheckGround();
    }
    private void Update()
        {
            Run1();
            if (isGrounded && Input.GetButtonDown("Jump"))
                Jump();
            Flip();
            //  Attack();
        }
  /*  void Attack()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Rigidbody2D tempApple = Instantiate(apple, transform.position, Quaternion.identity);
            tempApple.AddForce(new Vector2(isRight ? 400 : -400, 0));
            if (!isRight)
            {
                SpriteRenderer srApple = tempApple.GetComponentInChildren<SpriteRenderer>();
                srApple.flipX = true;
                srApple.flipY = true;
            }
        }
    }*/
    void Flip ()
    {
        if(move < 0 && isRight)
        {
            isRight = false;
            sprite.flipX = true;
        }
        else if (move > 0 && !isRight)
        {
            isRight = true;
            sprite.flipX = false;
        }
    }
     private void Run1()
     {
         Vector3 dir = transform.right * move;
         if (Input.GetButton("Horizontal"))
         {
             transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
             sprite.flipX = dir.x < 0.0f;

         }
         anim.SetFloat("speedX", Mathf.Abs(dir.x));


     }
     private void Jump()
     {
         rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

     }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position + Vector3.down * 1.5f, 0.3f);
        isGrounded = collider.Length > 1;
        anim.SetBool("isGround", isGrounded);


    }


}


