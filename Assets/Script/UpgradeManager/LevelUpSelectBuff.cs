using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Services.Analytics;
using UnityEngine;

public class WeightedItem
{
    public int type;
    public float weight;

    public WeightedItem(int type, float weight)
    {
        this.type = type;
        this.weight = weight;
    }
}

public class LevelUpSelectBuff : MonoBehaviour
{
    [SerializeField] List<UpgradeData> upgradeList;
    [SerializeField] CharacterInfo_1 characterInfo;
    [SerializeField] private AnimationCurve animationCurve;

    public List<UpgradeData> weaponList = new List<UpgradeData>();
    public List<UpgradeData> itemList = new List<UpgradeData>();
    public List<UpgradeData> weaponUpgradeList = new List<UpgradeData>();
    public List<UpgradeData> itemUpgradeList = new List<UpgradeData>();
    public List<UpgradeData> statUpgrade = new List<UpgradeData>();
    public UpgradeData GainCoin;

    public List<UpgradeData> weaponAcquiredList = new List<UpgradeData>();
    public List<UpgradeData> itemAcquiredList = new List<UpgradeData>();

    List<WeightedItem> items = new List<WeightedItem>
    {
        new WeightedItem(0, 5), //GainCoin
        new WeightedItem(1, 15), //Stat Upgrade
        new WeightedItem(2, 40f), //Upgrade
        new WeightedItem(3, 40f) //Unlock
    };

    UpgradeData randomUp;

    int upgradeCount;

    public int GetRandomType(List<WeightedItem> items)
    {
        float totalWeight = items.Sum<WeightedItem>(item => item.weight);
        float randomValue = Random.Range(0, totalWeight);

        float weights = 0f;
        foreach(var item in items)
        {
            weights += item.weight;
            if(randomValue <= weights)
            {
                return item.type;
            }
        }

        return -1;
    }

    public void UpdateRate(int type, bool reset = false)
    {
        foreach(var item in items)
        {
            switch (item.type)
            {
                case 2: //Upgrade
                    {
                        item.weight = reset ? 40f : 0f;
                    }
                    break;
                case 3: //Unlock
                    {
                        item.weight = reset ? 40f : 0f;
                    }
                    break;
            }
        }
    }

    private void Awake()
    {
        foreach (var item in upgradeList)
        {
            item.acquired = false;
            
            switch ((int)item.upgradeType)
            {
                case 0: //WeaponUpgrade
                    {
                        weaponUpgradeList.Add(item);
                    }
                    break;
                case 1: //ItemUpgrade
                    {
                        itemUpgradeList.Add(item);
                    }
                    break;
                case 2: //WeaponUnlock
                    {
                        weaponList.Add(item);
                    }
                    break;
                case 3: //ItemUnlock
                    {
                        itemList.Add(item);
                    }
                    break;
                case 4: //StatUpgrade
                    {
                        statUpgrade.Add(item);
                    }
                    break;
                case 5: //GainCoin
                    {
                        GainCoin = item;
                    }
                    break;
            }
        }

        foreach (var item in weaponUpgradeList)
        {
            item.description = item.weaponData.weaponUpdateInfos[1].description;
            item.weaponData.stats = item.weaponData.weaponUpdateInfos[0].stats;
        }

        upgradeCount = upgradeList.Count;
    }

    /*public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        if (count > upgradeCount)
        {
            count = upgradeCount;
        }

        do
        {
            do
            {
                number = animationCurve.Evaluate(Random.Range(0f, 6f));

                if (number <= 1 && weaponAcquiredList.Count < 5) //Unlock Weapon
                {
                    randomUp = weaponList[Random.Range(0, weaponList.Count)];
                }
                else if (number <= 2 && itemAcquiredList.Count < 5) //Unlock Item
                {
                    randomUp = itemList[Random.Range(0, itemList.Count)];
                }
                else if (number <= 3) //Upgrade Weapon
                {
                    if (weaponAcquiredList.Count != 0 && weaponUpgradeList.Count != 0)
                    {
                        randomUp = weaponAcquiredList[Random.Range(0, weaponAcquiredList.Count)];
                        if (!upgradeList.Contains(randomUp))
                        {
                            foreach (var item in weaponUpgradeList)
                            {
                                if (randomUp.weaponData.name == item.weaponData.name)
                                {
                                    randomUp = item;
                                }
                            }

                            if (randomUp.acquired && randomUp.weaponData.stats.level < 7)
                            {
                                randomUp.acquired = false;
                                randomUp.description = randomUp.weaponData.weaponUpdateInfos[randomUp.weaponData.stats.level - 1].description;
                                randomUp.weaponData.stats = randomUp.weaponData.weaponUpdateInfos[randomUp.weaponData.stats.level - 1].stats;
                            }
                            else if (randomUp.acquired && randomUp.weaponData.stats.level == 7)
                            {
                                weaponUpgradeList.Remove(randomUp);
                                randomUp = null;
                            }
                        }
                        else
                        {
                            randomUp = null;
                        }
                    }
                }
                else if (number <= 4) //Upgrade Iteom
                {
                    //randomUp = itemUpgradeList[Random.Range(0, itemUpgradeList.Count)];
                }
                else if (number <= 5) //Stat Upgrade
                {
                    randomUp = statUpgrade[Random.Range(0, statUpgrade.Count)];
                }
                else if (number <= 6) //Gain Coin
                {
                    randomUp = GainCoin;
                }
            }
            while (randomUp == null);

            if (!upgradeList.Contains(randomUp))
            {
                if (!randomUp.acquired)
                {
                    upgradeList.Add(randomUp);
                    randomUp = null;
                }
            }
        } while (upgradeList.Count < count);

        return upgradeList;
    }*/

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        if (count > upgradeCount)
        {
            count = upgradeCount;
        }

        do
        {
            int type = GetRandomType(items);

            switch (type)
            {
                case 0: //GainCoin
                    {
                        randomUp = GainCoin;
                    }break;
                case 1: //Stat Upgrade
                    {
                        randomUp = statUpgrade[Random.Range(0, statUpgrade.Count)];
                    }
                    break;
                case 2: //Upgrade
                    {
                        int randomUpType = -1;

                        if(weaponAcquiredList.Count<UpgradeData>(item => item.weaponData.stats.level < 7) != 0)
                        {
                            randomUpType = 0;
                        }

                        if (weaponAcquiredList.Count<UpgradeData>(item => item.weaponData.stats.level == 7) == 5)
                        {
                            UpdateRate(type);
                            break;
                        }
                        //randomUpType = Random.Range(0, 2);

                        switch (randomUpType)
                        {
                            case 0: //Weapon
                                {
                                    do
                                    {
                                        UpgradeData randomUpdate = weaponAcquiredList[Random.Range(0, weaponAcquiredList.Count)];

                                        foreach (var item in weaponUpgradeList)
                                        {
                                            if(item.weaponData.name == randomUpdate.weaponData.name)
                                            {
                                                randomUp = item;
                                            }
                                        }
                                    }
                                    while (randomUp == null);
                                }break;
                            case 1: //Item
                                {

                                }
                                break;
                        }
                    }
                    break;
                case 3: //Unlock
                    {
                        int randomUpType = -1;

                        if (weaponAcquiredList.Count == 5 && itemAcquiredList.Count == 5)
                        {
                            UpdateRate(type);
                            break;
                        }

                        if (weaponAcquiredList.Count < 5 && itemAcquiredList.Count < 5)
                        {
                            randomUpType = Random.Range(0, 2);
                        }
                        else
                        {
                            if(weaponAcquiredList.Count == 5)
                            {
                                randomUpType = 1;
                            }

                            if (itemAcquiredList.Count == 5)
                            {
                                randomUpType = 0;
                            }
                        }

                        switch (randomUpType)
                        {
                            case 0: //Weapon
                                {
                                    randomUp = weaponList[Random.Range(0, weaponList.Count)];
                                }
                                break;
                            case 1: //Item
                                {
                                    randomUp = itemList[Random.Range(0, itemList.Count)];
                                }
                                break;
                        }
                    }
                    break;
            }

            if (!upgradeList.Contains(randomUp) && randomUp != null)
            {
                if (!randomUp.acquired)
                {
                    upgradeList.Add(randomUp);
                    randomUp = null;
                }
            }
        } while (upgradeList.Count < count);

        return upgradeList;
    }

    public void WeaponAcquired(UpgradeData weaponA)
    {
        weaponAcquiredList.Add(weaponA);
        weaponA.acquired = true;
        weaponList.Remove(weaponA);
        UpdateRate(2, true);
    }

    public void WeaponNextUpgradeInfo(UpgradeData weaponA)
    {
        if (weaponA.weaponData.stats.level < 7)
        {
            weaponA.acquired = false;
            weaponA.weaponData.stats = weaponA.weaponData.weaponUpdateInfos[weaponA.weaponData.stats.level].stats;
            if(weaponA.weaponData.stats.level == 7)
                return;
            weaponA.description = weaponA.weaponData.weaponUpdateInfos[weaponA.weaponData.stats.level].description;
        }
    }

    public void ItemAcquired(UpgradeData itemA)
    {
        itemAcquiredList.Add(itemA);
        itemA.acquired = true;
        itemList.Remove(itemA);
    }
}
