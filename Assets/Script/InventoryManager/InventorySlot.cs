using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] GameObject level;
    [SerializeField] Text levelText;

    public void SetWeaponSlot(UpgradeData weaponData, Sprite icon)
    {
        this.icon.sprite = icon;
        level.SetActive(true);
        levelText.text = string.Format("Lv. {0}", weaponData.level);
    }

    public void SetItemSlot(ItemsData itemData, Sprite icon)
    {
        this.icon.sprite = icon;
        level.SetActive(true);
        levelText.text = string.Format("Lv. {0}", itemData.level);
    }
}
