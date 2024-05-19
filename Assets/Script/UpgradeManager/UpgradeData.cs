using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    WeaponUpgrade,
    ItemUpgrade,
    WeaponUnlock,
    ItemUnlock,
    StatUpgrade,
    GainCoin
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
