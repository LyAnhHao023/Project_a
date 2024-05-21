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

    private void Awake()
    {
        SetCharacterStats();
        ObjectDrops = GameObject.Find("===ObjectDrop===").transform;
        
        
    }
    public override void Attack()
    {
        for(int i = 0; i < numberBombDrop; i++)
        {
            GameObject newBomb=Instantiate(BombChildrenPrefab, transform.position,Quaternion.identity);
            newBomb.transform.parent = ObjectDrops;
            newBomb.transform.position = transform.position;
        }
    }

    

    public override void SetCharacterStats()
    {
        characterStats = GetComponentInParent<CharacterInfo_1>().characterStats;
    }
}
