using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator anim;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {

            anim.SetTrigger("open");
            Destroy(this);
            Destroy(GetComponent<Collider2D>());
            // Destroy(rb);
            Destroy(transform.parent.gameObject);


        }

    }
}
