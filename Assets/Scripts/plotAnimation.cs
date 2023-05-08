using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plotAnimation : MonoBehaviour
{
    Animator an;

    private void Start()
    {
        an = gameObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "ball")
        {
            an.Play("plot-hit");
        }

        
    }
}
