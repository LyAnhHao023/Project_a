using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CharacterInfo_1 : MonoBehaviour
{
    public InventorySlotsManager inventorySlotsManager;

    public MenuManager menuManager;

    public int currentHealth;

    public HealthBar healthBar;

    public ExpBar expBar;
    public Slider expSlider;
    public int level;
    public int maxExpValue;

    public float elapsedTime;

    public CountSys countSys;

    public GameOverCoin overCoin;

    public PlayerStatShow statShow;

    [SerializeField] LevelUpSelectBuff levelUpSelectBuff;

    List<UpgradeData> upgradeDatas;
    List<UpgradeData> weaponSlotsManager = new List<UpgradeData>();
    List<UpgradeData> itemSlotsManager = new List<UpgradeData>();

    [SerializeField] WeaponsManager weaponsManager;
    [SerializeField] PassiveItemsManager itemsManager;

    int currentExp;

    private int coins = 0;

    int maxHealth;

    public float healthPercent = 0;
    public float attackPercent = 0;
    public float speedPercent = 0;
    public float critPercent = 0;

    int baseHealth;
    int baseAttack;
    float baseCrit;
    int baseSpeed;

    GameObject character;
    public CharacterStats characterStats;

    int speed = 5;

    public int numberMonsterKilled=0;

    private void Awake()
    {
        character = GameObject.Find("FistCharDev");
        characterStats = character.GetComponent<CharacterStats>();

        baseAttack = characterStats.strenght;
        baseCrit = characterStats.crit;
        baseSpeed = characterStats.speed;
        baseHealth = characterStats.maxHealth;

        maxHealth = characterStats.maxHealth;
        currentHealth = maxHealth + Mathf.FloorToInt(characterStats.maxHealth*healthPercent);
        healthBar.SetMaxHealth(maxHealth);

        weaponSlotsManager.Add(characterStats.beginerWeapon);
        weaponsManager.AddWeapon(characterStats.beginerWeapon.weaponData);
        inventorySlotsManager.WeaponSlotUpdate(weaponSlotsManager);

        level = 1;
        maxExpValue = 10;
        currentExp = 0;
        expBar.SetMaxExp(level, maxExpValue);
        countSys.SetCoinCount(0);
        countSys.SetKillCount(0);
        overCoin.SetCoinGain(0);

        statShow.SetHealth(maxHealth);
        statShow.SetAttack(characterStats.strenght);
        statShow.SetSpeed(characterStats.speed);
        statShow.SetCrit(characterStats.crit);
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

        elapsedTime += Time.deltaTime;
    }

    public void KilledMonster()
    {
        ++numberMonsterKilled;
        countSys.SetKillCount(numberMonsterKilled);
    }

    public void GainCoin(int coinGain)
    {
        coins += coinGain;
        countSys.SetCoinCount(coins);
    }

    public void GainExp(int exp)
    {
        currentExp += exp;

        if(currentExp >= maxExpValue)
        {
            LevelUp();
        }

        expBar.SetExp(currentExp);
    }

    public void LevelUp()
    {
        upgradeDatas = levelUpSelectBuff.GetUpgrades(4);
        menuManager.LevelUpScene(upgradeDatas);
        currentExp -= maxExpValue;
        level += 1;
        maxExpValue += Mathf.FloorToInt((float)(maxExpValue * 0.5));
        expBar.SetMaxExp(level, maxExpValue);
    }

    public void Upgrade(int id)
    {
        switch ((int)upgradeDatas[id].upgradeType)
        {
            case 0: //WeaponUpgrade
                {

                }break;
            case 1: //ItemUpgrade
                {

                }
                break;
            case 2: //WeaponUnlock
                {
                    weaponSlotsManager.Add(upgradeDatas[id]);
                    weaponsManager.AddWeapon(upgradeDatas[id].weaponData);
                    inventorySlotsManager.WeaponSlotUpdate(weaponSlotsManager);
                    upgradeDatas[id].acquired = true;
                }
                break;
            case 3: //ItemUnlock
                {
                    itemSlotsManager.Add(upgradeDatas[id]);
                    itemsManager.AddItem(upgradeDatas[id].itemsData);
                    inventorySlotsManager.ItemSlotUpdate(itemSlotsManager);
                    upgradeDatas[id].acquired = true;
                }
                break;
            case 4: //StatUpgrade
                {
                    if (upgradeDatas[id].buffName.Contains("ATK"))
                    {
                        attackPercent += (float)0.1;
                        characterStats.strenght = baseAttack + Mathf.FloorToInt((float)baseAttack * attackPercent);
                        statShow.SetAttack(characterStats.strenght);
                    }
                    if (upgradeDatas[id].buffName.Contains("CRT"))
                    {
                        critPercent += 2;
                        characterStats.crit = baseCrit + critPercent;
                        statShow.SetCrit(characterStats.crit);
                    }
                    if (upgradeDatas[id].buffName.Contains("HP"))
                    {
                        healthPercent += (float)0.1;
                        characterStats.maxHealth = baseHealth + Mathf.FloorToInt((float)baseHealth * healthPercent);
                        maxHealth = characterStats.maxHealth;
                        statShow.SetHealth(characterStats.maxHealth);
                        healthBar.SetMaxHealth(characterStats.maxHealth);
                        healthBar.SetHealth(currentHealth);
                    }
                    if (upgradeDatas[id].buffName.Contains("SPD"))
                    {
                        speedPercent += (float)0.05;
                        characterStats.speed = baseSpeed + Mathf.FloorToInt((float)baseSpeed * speedPercent);
                        statShow.SetSpeed(characterStats.speed);
                    }
                }
                break;
            case 5: //GainCoin
                {

                }
                break;
        }

        menuManager.LevelUpDone();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            menuManager.GameOverScreen();
            coins = CoinGainPercent(coins, Mathf.FloorToInt(elapsedTime % 60));
            overCoin.SetCoinGain(coins);
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

    public int CoinGainPercent(int coins, int timer)
    {
        if (timer <= 600)
            return ((int)((float)(coins * 0.25)));
        else if (timer <= 900)
            return ((int)((float)(coins * 0.5)));
        else if (timer <= 1200)
            return ((int)((float)(coins * 0.75)));

        return coins;
    }
}

