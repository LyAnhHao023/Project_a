using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class AxeWeapon : WeaponBase
{

    [SerializeField] GameObject rightAxe;
    [SerializeField] GameObject leftAxe;

    [SerializeField]
    private Vector2 AxeAttackSize=new Vector2(4f,3f);

    playerMove playerMove;

    CharacterStats characterStats;

    WeaponStats baseStat = new WeaponStats(2, 1, 1f);

    private void Awake()
    {
        playerMove = GetComponentInParent<playerMove>();
        SetCharacterStats();
    }


    public void ApllyDmg(Collider2D collision)
    {
        EnemyBase z = collision.GetComponent<EnemyBase>();
        if (z != null)
        {
            bool isCrit = UnityEngine.Random.value * 100 < characterStats.crit;
            float dmg = isCrit ?
                (weaponStats.dmg + characterStats.strenght) * characterStats.critDmg : (weaponStats.dmg + characterStats.strenght);

            PostDmg((int)dmg, z.transform.position, isCrit);

            bool isDead = z.EnemyTakeDmg((int)dmg);
            if (isDead)
            {
                GetComponentInParent<CharacterInfo_1>().KilledMonster();
            }

        }
    }

    public override void Attack()
    {
        if (playerMove.scaleX == 1)
        {
            rightAxe.SetActive(true);
            //Lay danh sach thong tin cua vat the ma Axe va cham
            //colliders = Physics2D.OverlapBoxAll(rightAxe.transform.position, AxeAttackSize, 0f);
        }
        else
        {
            leftAxe.SetActive(true);
            //colliders = Physics2D.OverlapBoxAll(leftAxe.transform.position, AxeAttackSize, 0f);
        }

        //Lay danh sach thong tin cua vat the ma Axe va cham

        //if (colliders.Length > 0)
        //{
        //    ApllyDmg(colliders);
        //}
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
