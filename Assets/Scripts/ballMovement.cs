using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ballMovement : MonoBehaviour
{
    [SerializeField] int maxSpeed;
    [SerializeField] int power;
    [SerializeField] int bounceRange;
    [SerializeField] int maxShot; 
    [SerializeField] float scaleRatio;


    Ball ball;

    Rigidbody2D rb;

    Vector3 force, startPos, endPos;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        ball = gameObject.GetComponent<Ball>();
        ball.maxShot = maxShot;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "tree")
        {
            rb.velocity *= 0.4f;
        }

        rb.AddForce(-collision.contacts[0].normal + new Vector2(Random.Range(0, bounceRange), Random.Range(0, bounceRange)) + rb.velocity);

    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
    private void Update()
    {

        if (ball.shot < ball.maxShot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButtonUp(0))
            {
                endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                force = new Vector2(startPos.x - endPos.x, startPos.y - endPos.y);
                rb.velocity = force * power;
                // just one shot
                ball.shot++;
            }
        }

        if (rb.velocity.sqrMagnitude > 0.1 && ball.scale < ball.maxScale)
        {
            ball.scale += scaleRatio / 1000;
            ball.moves = true;
        }

        if (rb.velocity.sqrMagnitude < 0.1 && ball.shot <= ball.maxShot)
        {
            ball.moves = false;
        }
    }
}
