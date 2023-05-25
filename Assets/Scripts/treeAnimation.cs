using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeAnimation : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites;

    [SerializeField]
    string animationPlay;

    Animator an;
    SpriteRenderer sr;

    private void Start()
    {
        an = gameObject.GetComponent<Animator>();
        sr = gameObject.GetComponent<SpriteRenderer>();

        sr.sprite = sprites[Random.Range(0, 6)];
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "ball") {
            an.Play(animationPlay);
        }
    }   
}
