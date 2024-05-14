using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo_1 : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public ExpBar expBar;
    public Slider expSlider;
    public int level;
    public int maxExpValue;

    int currentExp;

    private int coins=0;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(2);
        }

    }

    public void GainCoin(int coinGain)
    {
        coins += coinGain;
    }

    public void GainExp(int exp)
    {
        for (int i = 0; i < exp; i++)
        {
            currentExp += 1;
            expBar.SetExp(currentExp);

            if (expSlider.value == expSlider.maxValue)
            {
                level++;
                maxExpValue += maxExpValue % 10 + 5;

                expBar.SetMaxExp(level, maxExpValue);
                currentExp = 0;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            EditorApplication.isPaused = !EditorApplication.isPaused;
            int coinLocal = PlayerPrefs.GetInt("Coins", 0);
            //Debug.Log(coinLocal +" local");
            PlayerPrefs.SetInt("Coins", coinLocal+coins);
            PlayerPrefs.Save();
            //Debug.Log(PlayerPrefs.GetInt("Coins", 0));
        }
    }

    public void HealthByPercent(int health)
    {
        currentHealth += maxHealth * health/100;
        if(currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }
}
