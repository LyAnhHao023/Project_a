using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BombScript : WeaponBase
{
    CharacterStats characterStats;

    [SerializeField]
    GameObject BombChildrenPrefab;

    Transform ObjectDrops;

    [SerializeField]
    int numberBombDrop=1;

    [SerializeField]
    WeaponStats baseStat = new WeaponStats(5, 1, 3f);

    private void Awake()
    {
        SetCharacterStats();
        BuffWeaponSizeByPersent(GetComponentInParent<CharacterInfo_1>().weaponSize);
        ObjectDrops = GameObject.Find("===ObjectDrop===").transform;
    }
    public override void Attack()
    {
        switch (weaponStats.level)
        {
            case 1:
                {
                    numberBombDrop = 1;
                }
                break;
            case 4:
                {
                    numberBombDrop = 2;
                }
                break;
            case 7:
                {
                    numberBombDrop = 3;
                }
                break;
        }

        for(int i = 0; i < numberBombDrop; i++)
        {
            GameObject newBomb=Instantiate(BombChildrenPrefab, transform.position,Quaternion.identity);
            newBomb.transform.parent = ObjectDrops;
            newBomb.transform.position = transform.position;
            newBomb.transform.localScale = transform.localScale;
        }
    }

    public override void SetCharacterStats()
    {
        characterStats = GetComponentInParent<CharacterInfo_1>().characterStats;
    }

    public override WeaponStats GetBaseStat()
    {
        return baseStat;
    }
}
