using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Ball : MonoBehaviour {
    public float maxScale;

    public Rigidbody2D rb;

    public bool moves = true;

    UI ui;

    public float scale;
    public float defaultScale;
    float size;
    public float speed;
    
    
    public int shot;
    public int maxShot;

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
        ui = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<UI>();

        scale = 1f;
        defaultScale = scale;
    }

    void Update()
    {
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
        Size = ((scale - defaultScale) / (maxScale - defaultScale)) * 100f;
        if (ui != null)
        {
            ui.UpdateUI(Size);
            ui.UpdateUISec(shot, maxShot);

        }
        
        // Debug.Log("SIZE IN 0 - 100: " + Size + ",DS: " + defaultScale + ",Scale: " + scale);
    }
}
