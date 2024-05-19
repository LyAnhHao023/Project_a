using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] GameObject level;
    [SerializeField] Text levelText;

    public void SetWeaponSlot(UpgradeData weaponData)
    {
        icon.sprite = weaponData.icon;
        level.SetActive(true);
        levelText.text = string.Format("Lv. {0}", weaponData.weaponData.stats.level);
    }

    public void SetItemSlot(UpgradeData itemData)
    {
        icon.sprite = itemData.icon;
        level.SetActive(true);
        levelText.text = string.Format("Lv. {0}", itemData.itemsData.level);
    }
}
