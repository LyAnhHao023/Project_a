using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWeapon : ItemBase
{
    [SerializeField]
    float persentBuffBigWeapons;

    private void Awake()
    {
        level = 1;
        SetItemStat();
    }
    public override void ItemEffect()
    {
        GameObject gameObject = GameObject.Find("Weapons");
        gameObject.transform.localScale= new Vector3(1f*persentBuffBigWeapons,1f*persentBuffBigWeapons,1);
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
