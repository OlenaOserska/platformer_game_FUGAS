using System.Collections;

using UnityEngine;

using TMPro;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private int lives = 3;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private int coins;
    [SerializeField] private TextMeshProUGUI textMoney;
    [SerializeField] private Transform chackpoint;
    [SerializeField] private Transform startpoint;
    [SerializeField] private Rigidbody2D apple;
   // [SerializeField] private TextMeshProUGUI textEye;
    [SerializeField] private GameUI gameUI;

    private bool isRight = true;
    private bool isGrounded = false;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
     private int goldCount = 0;
   
    private Rigidbody2D tempApple;
    private bool IsControl = true;
    private float move;

    public static object Intance { get; internal set; }
    public int GoldCount
    {
        get => goldCount;
    }
    public void Start()
    {
        coins= UserDataController.Instance.userData.Coins;
        lives= UserDataController.Instance.userData.Lives;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coins")
        {
           
            UserDataController.Instance.AddCoins(10);
            int updatedCoins = UserDataController.Instance.userData.Coins;
            gameUI.SetCountCoinsUI(updatedCoins);
            

            Destroy(collision.gameObject);
        }
        if (collision.transform.tag == "Boy")
        {
            Damage();
        }
        if (collision.tag == "roga")
        {
           
            goldCount += 50;
            textMoney.text = goldCount.ToString();

            Destroy(collision.gameObject);
        }
        if (collision.transform.tag == "Spike")
        {
            Damage();
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
        {
        if (collision.transform.tag == "Fire")
        {
            Damage();
        }
        if (collision.transform.tag == "Spike")
        {
            Damage();
        }
        if (collision.transform.tag == "thorn")
        {
            Damage();
        }
        if (collision.transform.tag == "Floor")
        {
            Damage();

        }

    } 
    private void Resetpoint()
    {
        if (transform.position.x < chackpoint.position.x)
        {
            transform.position = startpoint.position;
        }
        else if (transform.position.x > chackpoint.position.x)
        {
            transform.position = chackpoint.position; 
        }
    }
    IEnumerator StopControl()
    {
        IsControl = false;
        yield return new WaitForSeconds(1);
        IsControl = true;
    }
    private void Damage()
    {
        UserDataController.Instance.RemoveHealth(1);
        int updatedLives = UserDataController.Instance.userData.Lives;
        print(updatedLives);
        gameUI.UpdateHeart(updatedLives);
        Resetpoint();
        if (updatedLives <= 0)
        {
            Time.timeScale = 0;
            gameUI.GameOver();
        }
    }
           private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
       
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
        Attack();
    }
     void Attack()
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
      }
    void Flip()
    {
        if (move < 0 && isRight)
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


    



