using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenScript : WeaponBase
{
    [SerializeField]
    GameObject ShurikenChildren;

    CharacterStats characterStats;

    
    private void Awake()
    {
        SetCharacterStats();
        transform.localScale=GameObject.Find("Weapons").transform.localScale;
    }

    public override void Attack()
    {
        ShurikenChildren.transform.position = transform.position;
        ShurikenChildren.SetActive(true);
    }

    public void ApllyDmg(Collider2D collision)
    {
        EnemyBase enemy = collision.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            bool isCrit = Random.value * 100 < characterStats.crit;
            float dmg = isCrit ?
                (weaponStats.dmg + characterStats.strenght) * characterStats.critDmg : (weaponStats.dmg + characterStats.strenght);

            PostDmg((int)dmg, enemy.transform.position, isCrit);

            bool isDead = enemy.EnemyTakeDmg((int)dmg);
            if (isDead)
            {
                GetComponentInParent<CharacterInfo_1>().KilledMonster();
            }

        }
    }

    public override void SetCharacterStats()
    {
        characterStats=GetComponentInParent<CharacterInfo_1>().characterStats;
    }
}
