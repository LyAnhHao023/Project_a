using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSelectBuff : MonoBehaviour
{
    [SerializeField] public List<UpgradeData> upgrades;
    [SerializeField] CharacterInfo_1 characterInfo;

    UpgradeData randomUp;

    private void Awake()
    {
        foreach (var item in upgrades)
        {
            if(item.weaponData == characterInfo.characterData.beginerWeapon)
                item.acquired = true;
            else
                item.acquired = false;
        }
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();

        if (count > upgrades.Count)
        {
            count = upgrades.Count;
        }

        do
        {
            randomUp = upgrades[Random.Range(0, upgrades.Count)];
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
