using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    WeaponUpgrade = 0,
    ItemUpgrade = 1,
    WeaponUnlock = 2,
    ItemUnlock = 3,
    StatUpgrade = 4,
    GainCoin = 5
}

[CreateAssetMenu]
public class UpgradeData : ScriptableObject
{
    public UpgradeType upgradeType;
    public string buffName;
    public Sprite icon;
    public string description;
    public WeaponData weaponData;
    public ItemsData itemsData;
    public bool acquired = false;

    public void Awake()
    {
        acquired = false;
    }
}
