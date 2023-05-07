using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    Slider slider;


    void Start()
    {
        
    }

    public void UpdateUI(float value)
    {
        slider.value = value;
    }
}
