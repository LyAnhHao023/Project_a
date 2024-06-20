using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenScript : WeaponBase
{
    [SerializeField]
    List<GameObject> ShurikenChildrenLst;
    [SerializeField]
    List<GameObject> ShurikenChildrenLst1;

    CharacterStats characterStats;

    List<GameObject> ActiveShurikenChildrenLst = new List<GameObject>();

    WeaponStats baseStat = new WeaponStats(5, 1, 10f);

    private void Awake()
    {
        SetCharacterStats();
        BuffWeaponSizeByPersent(GetComponentInParent<CharacterInfo_1>().weaponSize);
    }

    public override void Attack()
    {
        ActiveShurikenChildrenLst.Clear();

        foreach(GameObject child in ShurikenChildrenLst)
        {
            if (!child.activeSelf)
            {
                ActiveShurikenChildrenLst.Add(child);
                break;
            }
        }

        if(weaponStats.level >= 4)
        {
            foreach (GameObject child in ShurikenChildrenLst1)
            {
                if (!child.activeSelf)
                {
                    ActiveShurikenChildrenLst.Add(child);
                    break;
                }
            }
        }


        foreach (GameObject child in ActiveShurikenChildrenLst)
        {
            child.transform.position = transform.localPosition;
            child.SetActive(true);
        }
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

    public override WeaponStats GetBaseStat()
    {
        return baseStat;
    }
}
