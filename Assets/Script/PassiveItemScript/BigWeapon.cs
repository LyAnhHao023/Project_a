using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWeapon : ItemBase
{
    [SerializeField]
    float persentBuffBigWeapons;

    private void Start()
    {
        level = 1;
        SetItemStat();
    }
    public override void ItemEffect()
    {
        GetComponentInParent<CharacterInfo_1>().weaponSize += persentBuffBigWeapons - 1;

        List<weaponEnquip> weapons = GetComponentInParent<WeaponsManager>().weapons_lst;

        foreach (weaponEnquip weapon in weapons)
        {
            weapon.weaponObject.GetComponent<WeaponBase>().BuffWeaponSizeByPersent(persentBuffBigWeapons);
        }
    }

    public override void SetItemStat()
    {
        switch (level)
        {
            case 1:
                {
                    persentBuffBigWeapons = 1.2f;
                }
                break;
            case 2:
                {
                    persentBuffBigWeapons = 1.4f;
                }
                break;
            case 3:
                {
                    persentBuffBigWeapons = 1.6f;
                }
                break;
            case 4:
                {
                    persentBuffBigWeapons = 1.8f;
                }
                break;
        }

        ItemEffect();
    }
}
