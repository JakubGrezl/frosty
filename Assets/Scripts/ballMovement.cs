using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ballMovement : MonoBehaviour
{
    [SerializeField]
    Vector3 minPower, maxPower;

    Rigidbody2D rb;

    [SerializeField]
    int power;

    Vector3 force;

    Vector3 startPos;
    Vector3 endPos;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(startPos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            force = new Vector2(Mathf.Clamp(startPos.x - endPos.x, minPower.x, maxPower.x), Mathf.Clamp(startPos.y - endPos.y, minPower.y, maxPower.y));
            Debug.Log(force);
            rb.AddForce(force * power, ForceMode2D.Impulse);
        }
    }
}
