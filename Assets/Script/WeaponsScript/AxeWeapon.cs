using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class AxeWeapon : WeaponBase
{

    [SerializeField] GameObject rightAxe;
    [SerializeField] GameObject leftAxe;

    playerMove playerMove;

    CharacterStats characterStats;

    bool isActiveTwoAxe=false;

    bool isKnockBack=false;

    float buffATK;

    private void Start()
    {
        playerMove = GetComponentInParent<playerMove>();
        SetCharacterStats();
        BuffWeaponSizeByPersent(GetComponentInParent<CharacterInfo_1>().weaponSize);
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
            //KnockBack
            if (!z.GetComponent<Collider2D>().isTrigger && isKnockBack)
            {
                Vector2 knockbackDirection = (z.transform.position - transform.position).normalized;
                z.Knockback(knockbackDirection, 3);
            }

        }
    }

    public override void Attack()
    {
        if (isActiveTwoAxe)
        {
            StartCoroutine(ActiveTwoAxe());
        }
        else
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
        }

        //Lay danh sach thong tin cua vat the ma Axe va cham

        //if (colliders.Length > 0)
        //{
        //    ApllyDmg(colliders);
        //}
    }

    private IEnumerator ActiveTwoAxe()
    {
        rightAxe.SetActive(true);
        yield return new WaitForSeconds(0.15f);
        leftAxe.SetActive(true);

    }

    public override void SetCharacterStats()
    {
        characterStats = GetComponentInParent<CharacterInfo_1>().characterStats;
    }

    public override void LevelUp()
    {
        weaponStats.level++;
        switch (weaponStats.level)
        {
            case 2:
                {
                    //Increase area by 40%.
                    BuffWeaponSizeByPersent(0.4f);
                   
                }
                break;
            case 3:
                {
                    //Increase damage by 30%.
                    buffATK += 0.3f;
                    SetStat();
                }
                break;
            case 4:
                {
                    //Increase area by 40%.
                    BuffWeaponSizeByPersent(0.4f);
                    //Increase frequency of hits by 30%.
                    weaponStats.timeAttack -= weaponData.stats.timeAttack * 30 / 100;
                }
                break;
            case 5:
                {
                    //can active 2 axe at sametime, Increase damage by 30%.
                    isActiveTwoAxe = true;
                    buffATK += 0.2f;
                    SetStat();
                }
                break;
            case 6:
                {
                    //Increase damage by 60%.
                    buffATK += 0.6f;
                    SetStat();
                }
                break;
            case 7:
                {
                    //Add small knockback on hit.
                    isKnockBack = true;
                }
                break;

            default: break;
        }
    }

    void SetStat()
    {
        weaponStats.dmg = weaponData.stats.dmg + (int)Mathf.Ceil(weaponData.stats.dmg * buffATK);
    }
}
