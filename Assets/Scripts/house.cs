using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class house : MonoBehaviour
{
    [SerializeField] ball ball;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "ball" && ball.Size >= 100)
        {
            Debug.Log("U won");
            ball.rb.velocity = Vector3.zero;
        }
    }
}
