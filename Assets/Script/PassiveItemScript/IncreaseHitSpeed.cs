using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IncreaseHitSpeed : ItemBase
{
    [SerializeField]
    int persentSpeedIncrease;
    List<weaponEnquip> weaponEnquips_lst;

    bool isJustEnquip=true;

    private void Start()
    {
        ItemEffect();
    }
    public override void ItemEffect()
    {
        // get list weapon enquiped and buff attack speed
        weaponEnquips_lst = GetComponentInParent<WeaponsManager>().weapons_lst;
        foreach (var item in weaponEnquips_lst)
        {
            
            float curentTimeAttack = item.weaponObject.GetComponent<WeaponBase>().weaponStats.timeAttack;
            Debug.Log(curentTimeAttack+"truoc khi tang");
            item.weaponObject.GetComponent<WeaponBase>().weaponStats.timeAttack -= curentTimeAttack * persentSpeedIncrease/100;
            Debug.Log(item.weaponObject.GetComponent<WeaponBase>().weaponStats.timeAttack+"Sau khi tang");
        }
        isJustEnquip=false;
    }

    public override void Update()
    {
        if (!isJustEnquip)
        {
            if (weaponEnquips_lst.Count < GetComponentInParent<WeaponsManager>().weapons_lst.Count)
            {
                float curentTimeAttack = weaponEnquips_lst.Last().weaponObject.GetComponent<WeaponBase>().weaponStats.timeAttack;
                weaponEnquips_lst.Last().weaponObject.GetComponent<WeaponBase>().weaponStats.timeAttack -= curentTimeAttack * persentSpeedIncrease / 100;
            }
        }
        
    }

}
