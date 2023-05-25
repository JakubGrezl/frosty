using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Slider slider2;

    public void UpdateUI(float value)
    {
        slider.value = value;
    }

    public void UpdateUISec(float value, float maxValue)
    {
        slider2.maxValue = maxValue;
        slider2.value = maxValue - value;
    }
}
