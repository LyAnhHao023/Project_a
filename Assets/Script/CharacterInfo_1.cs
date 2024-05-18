using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CharacterInfo_1 : MonoBehaviour
{
    public int currentHealth;

    public HealthBar healthBar;

    public ExpBar expBar;
    public Slider expSlider;
    public int level;
    public int maxExpValue;

    int currentExp;

    private int coins = 0;

    int maxHealth = 100;

    GameObject character;
    public CharacterStats characterStats;

    int speed = 5;

    public int numberMonsterKilled=0;


    private void Awake()
    {
        character = GameObject.Find("FistCharDev");
        characterStats = character.GetComponent<CharacterStats>();

        currentHealth = characterStats.maxHealth;
        healthBar.SetMaxHealth(characterStats.maxHealth);

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

    public void KilledMonster()
    {
        ++numberMonsterKilled;
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

    public void HealthByNumber(int health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }
}

