using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class halda : MonoBehaviour
{
    [SerializeField] ball ball;

    Animator an;

    private void Start()
    {
        an = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ball")
        {
            ball.rb.velocity *= 5f;
            an.Play("haldahit");
            
            Destroy(gameObject, 1f);
        }
    }
}
