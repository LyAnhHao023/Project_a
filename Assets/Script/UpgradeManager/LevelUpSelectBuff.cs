using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSelectBuff : MonoBehaviour
{
    [SerializeField] public List<UpgradeData> weaponList;
    [SerializeField] List<UpgradeData> itemList;
    [SerializeField] List<UpgradeData> weaponUpgradeList;
    [SerializeField] List<UpgradeData> itemUpgradeList;
    [SerializeField] List<UpgradeData> statUpgrade;
    [SerializeField] UpgradeData CoinGain;
    [SerializeField] CharacterInfo_1 characterInfo;
    [SerializeField] private AnimationCurve animationCurve;
   
    UpgradeData randomUp;

    int upgradeCount;
    float number;

    private void Awake()
    {
        foreach (var item in weaponList)
        {
            if(item.weaponData == characterInfo.characterData.beginerWeapon)
                item.acquired = true;
            else
                item.acquired = false;
        }

        foreach (var item in itemList)
        {
            item.acquired = false;
        }

        upgradeCount = weaponList.Count + itemList.Count + weaponUpgradeList.Count + itemUpgradeList.Count + statUpgrade.Count + 1;
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        if (count > upgradeCount)
        {
            count = upgradeCount;
        }

        do
        {
            number = animationCurve.Evaluate(Random.Range(0, 6));
            if(number <= 1)
            {
                randomUp = weaponList[Random.Range(0, weaponList.Count)];
            }
            else if(number <= 2)
            {
                randomUp = itemList[Random.Range(0, itemList.Count)];
            }
            else if(number <= 3)
            {
                randomUp = weaponList[Random.Range(0, weaponList.Count)];
            }
            else if (number <= 4)
            {
                randomUp = itemList[Random.Range(0, itemList.Count)];
            }
            else if (number <= 5)
            {
                randomUp = statUpgrade[Random.Range(0, statUpgrade.Count)];
            }
            else
            {
                randomUp = CoinGain;
            }

            if (!upgradeList.Contains(randomUp))
            {
                if(!randomUp.acquired)
                    upgradeList.Add(randomUp);
            }
        } while (upgradeList.Count < count);

        return upgradeList;
    }

    public void Upgrade(int pressedButtonID)
    {
        characterInfo.Upgrade(pressedButtonID);
    }
}
