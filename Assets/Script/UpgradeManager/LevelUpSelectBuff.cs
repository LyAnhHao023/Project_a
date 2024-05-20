using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSelectBuff : MonoBehaviour
{
    [SerializeField] List<UpgradeData> upgrades;
    [SerializeField] CharacterInfo_1 characterInfo;

    UpgradeData randomUp;

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
