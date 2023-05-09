using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class house : MonoBehaviour
{
    [SerializeField] ball ball;

    Collider2D col;
    private void Start()
    {
        col = gameObject.GetComponent<Collider2D>();        
    }
    
    private void Update()
    {
        if (ball.Size >= 100) {
            col.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ball" && ball.Size >= 100)
        {
            ball.rb.velocity = Vector3.zero;
            SceneManager.LoadScene("level-selector");
        }
    }
}
