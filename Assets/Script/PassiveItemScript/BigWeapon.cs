using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWeapon : ItemBase
{
    [SerializeField]
    float persentBuffBigWeapons=1.2f;

    private void Awake()
    {
        ItemEffect();
    }
    public override void ItemEffect()
    {
        GameObject gameObject = GameObject.Find("Weapons");
        gameObject.transform.localScale= new Vector3(1f*persentBuffBigWeapons,1f*persentBuffBigWeapons,1);
    }
}
