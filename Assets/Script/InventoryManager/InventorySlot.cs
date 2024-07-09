using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] GameObject level;
    [SerializeField] Text levelText;

    public void ClearSlot(Sprite icon)
    {
        this.icon.sprite = icon;
        level.SetActive(false);

        levelText.text = "";
    }

    public void SetWeaponSlot(WeaponInfo weaponData)
    {
        this.icon.sprite = weaponData.Icon;
        level.SetActive(true);

        string overLevelText = "";

        if (weaponData.Overlevel > 0)
            overLevelText = string.Format("+{0}", weaponData.Overlevel);

        levelText.text = string.Format("Lv. {0}" + overLevelText, weaponData.level);
    }

    public void SetItemSlot(ItemsData itemData, Sprite icon)
    {
        this.icon.sprite = icon;
        level.SetActive(true);
        levelText.text = string.Format("Lv. {0}", itemData.level);
    }
}
