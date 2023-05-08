using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] 
    UI ui;
    [SerializeField] 
    public float maxScale;

    public Rigidbody2D rb;

    public bool moves = true;


    public float scale;
    public float defaultScale;
    float size;
    public float speed;

    public float Size
    {
        get
        {
            return size;    
        }

        set {

            if (value >= 100)
                size = 100;
            else size = value;
        }
    }

    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        scale = 1f;
        defaultScale = scale;
    }

    void Update()
    {
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
        Size = ((scale - defaultScale) / (maxScale - defaultScale)) * 100f;
        ui.UpdateUI(Size);
        
        // Debug.Log("SIZE IN 0 - 100: " + Size + ",DS: " + defaultScale + ",Scale: " + scale);
    }
}
