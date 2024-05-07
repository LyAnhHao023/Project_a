using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpTest : MonoBehaviour
{
    public ExpBar expBar;
    public Slider slider;
    public int level;
    public int maxExpValue;

    int currentExp;

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        maxExpValue = 10;
        currentExp = 0;
        expBar.SetMaxExp(level, maxExpValue);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GainExp(2);
        }
    }

    void GainExp(int exp)
    {
        for(int i = 0; i < exp; i++)
        {
            currentExp += 1;
            expBar.SetExp(currentExp);

            if (slider.value == slider.maxValue)
            {
                level++;
                maxExpValue += maxExpValue % 10 + 5;

                expBar.SetMaxExp(level, maxExpValue);
                currentExp = 0;
            }
        }
        Debug.Log(currentExp);
    }
}
