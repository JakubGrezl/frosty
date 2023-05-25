using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class house : MonoBehaviour
{
    Ball ball;
    private void Start()
    {
       
        ball = GameObject.Find("ball").GetComponent<Ball>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ball" && ball.Size >= 100)
        {
            ball.rb.velocity = Vector3.zero;
            SceneManager.LoadScene("level-selector");
        }
        
    }
}
