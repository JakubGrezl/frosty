using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halda : MonoBehaviour
{
    [SerializeField]
    int odchylka;

    Ball ball;
    Animator an;


    private void Start()
    {
        an = gameObject.GetComponent<Animator>();
        ball = GameObject.Find("ball").GetComponent<Ball>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ball")
        {
            ball.rb.velocity = ball.rb.velocity * 10f + new Vector2(Random.Range(-odchylka, odchylka), Random.Range(-odchylka, odchylka));
            an.Play("haldahit");
            
            Destroy(gameObject, 1f);
        }
    }
}
