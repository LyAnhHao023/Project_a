using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotsManager : MonoBehaviour
{
    [SerializeField] List<InventorySlot> weaponSlots = new List<InventorySlot>();
    [SerializeField] List<InventorySlot> itemSlots = new List<InventorySlot>();

    public void WeaponSlotUpdate(List<WeaponInfo> inventorySlots)
    {
        for (int i = 0; i < weaponSlots.Count; i++)
        {
            weaponSlots[i].ClearSlot();
            if (inventorySlots[i] != null)
            {
                weaponSlots[i].SetWeaponSlot(inventorySlots[i]);
            }
        }
    }

    public void ItemSlotUpdate(List<UpgradeData> inventorySlots)
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            itemSlots[i].SetItemSlot(inventorySlots[i].itemsData, inventorySlots[i].icon);
        }
    }
}
