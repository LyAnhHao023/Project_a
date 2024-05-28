using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int shield)
    {
        slider.maxValue = shield;
        slider.value = shield;
    }

    public void SetHealth(int shield)
    {
        slider.value = shield;
    }
}
