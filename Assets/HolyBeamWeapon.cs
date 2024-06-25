using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyBeamWeapon : WeaponBase
{

    [SerializeField] GameObject rightBeam;
    [SerializeField] GameObject leftBeam;

    playerMove playerMove;

    CharacterStats characterStats;

    bool isActiveTwoBeam=false;

    int knockBackMass = 4;

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
            if (!z.GetComponent<Collider2D>().isTrigger)
            {
                Vector2 knockbackDirection = (z.transform.position - transform.position).normalized;
                z.Knockback(knockbackDirection, knockBackMass);
            }
        }
    }


    public override void Attack()
    {
        if (isActiveTwoBeam)
        {
            ActiveTwoBeam();
        }
        else
        {
            if (playerMove.scaleX == 1)
            {
                rightBeam.SetActive(true);
            }
            else
            {
                leftBeam.SetActive(true);
            }
        }
    }

    private void ActiveTwoBeam()
    {
        rightBeam.SetActive(true);
        leftBeam.SetActive(true);

    }

    public override void SetCharacterStats()
    {
        characterStats = GetComponentInParent<CharacterInfo_1>().characterStats;
    }

    public override WeaponStats GetBaseStat()
    {
        throw new System.NotImplementedException();
    }

    public override void LevelUp()
    {
        weaponStats.level++;
        switch (weaponStats.level)
        {
            case 2:
                {
                    //Increase area by 30%.
                    BuffWeaponSizeByPersent(0.3f);

                }
                break;
            case 3:
                {
                    //Reduce attack cooldown by 30% seconds.
                    weaponStats.timeAttack -= weaponData.stats.timeAttack * 30 / 100;
                    
                }
                break;
            case 4:
                {
                    //Increase damage by 50%.
                    weaponStats.dmg += (int)Mathf.Ceil(weaponData.stats.dmg * 50 / 100);
                }
                break;
            case 5:
                {
                    //Reduce attack cooldown by 20% seconds, more knockback mass
                    weaponStats.timeAttack -= weaponData.stats.timeAttack * 30 / 100;
                    knockBackMass += 2;

                }
                break;
            case 6:
                {
                    //Increase size by 50%.
                    BuffWeaponSizeByPersent(0.5f);
                }
                break;
            case 7:
                {
                    //Fire an additional beam from behind
                    isActiveTwoBeam = true;
                }
                break;

            default: break;
        }
    }
}
