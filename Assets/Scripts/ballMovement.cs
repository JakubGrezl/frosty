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
    
    int shot;

    ball ball;

    Rigidbody2D rb;

    Vector3 force, startPos, endPos;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        ball = gameObject.GetComponent<ball>();
        ball.shot = shot;
        ball.maxShot = maxShot;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "tree")
        {
            rb.velocity *= 0.4f;
        }

        rb.AddForce(-collision.contacts[0].normal + new Vector2(Random.Range(-bounceRange, bounceRange), Random.Range(-bounceRange, bounceRange)));
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
    private void Update()
    {

        if (shot <= maxShot)
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
                shot++;
            }
        }

        if (rb.velocity.sqrMagnitude > 0.1 && ball.scale < ball.maxScale)
        {
            ball.scale += 0.002f;
            ball.moves = true;
        }

        if (rb.velocity.sqrMagnitude < 0.1 && shot <= maxShot)
        {
            ball.moves = false;
        }
    }
}
