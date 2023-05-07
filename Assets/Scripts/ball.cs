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
    public float scale;
    public float defaultScale;
    float size;


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

    // Start is called before the first frame update
    void Start()
    {
        scale = 1f;
        defaultScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3(scale, scale, scale);
        Size = ((scale - defaultScale) / (maxScale - defaultScale)) * 100f;
        ui.UpdateUI(Size);
        Debug.Log("SIZE IN 0 - 100: " + Size + ",DS: " + defaultScale + ",Scale: " + scale);
    }


}
