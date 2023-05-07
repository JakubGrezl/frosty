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

    bool shot;

    ball ball;

    Rigidbody2D rb;


    Vector3 force;

    Vector3 startPos;
    Vector3 endPos;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        ball = gameObject.GetComponent<ball>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "tree")
        {
            rb.velocity *= 0.4f;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
    private void Update()
    {

        if (!shot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButtonUp(0))
            {
                // neco jinýho nez addForce > bugguje se to a nevim co s tim delat XDDD

                endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                force = new Vector2(startPos.x - endPos.x, startPos.y - endPos.y);
                rb.velocity = force * power;
                // shot = true;
            }
        }

        if (rb.velocity.sqrMagnitude > 0.1 && ball.scale < ball.maxScale)
        {
            ball.scale += 0.005f;
        }
    }
}
