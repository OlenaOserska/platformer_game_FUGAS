using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMonsController : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    [SerializeField] private Transform MarkerL;
    [SerializeField] private Transform MarkerR;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private bool isRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
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


