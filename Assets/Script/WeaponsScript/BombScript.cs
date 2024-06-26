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

    int bomDrop = 0;

    float buffATK;

    private void Start()
    {
        SetCharacterStats();
        BuffWeaponSizeByPersent(GetComponentInParent<CharacterInfo_1>().weaponSize);
        ObjectDrops = GameObject.Find("===ObjectDrop===").transform;
    }

    public override void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = weaponStats.timeAttack;
            bomDrop += numberBombDrop;
        }

        if(bomDrop > 0)
        {
            bomDrop--;
            Attack();
        }
    }

    public override void Attack()
    {
        GameObject newBomb = Instantiate(BombChildrenPrefab, transform.position, Quaternion.identity);
        newBomb.transform.parent = ObjectDrops;
        newBomb.transform.position = transform.position;
        newBomb.transform.localScale = transform.localScale;
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
                    //Increase size by 15%.
                    BuffWeaponSizeByPersent(0.15f);
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
                    //Throw 2 bombs.
                    numberBombDrop = 2;
                }
                break;
            case 5:
                {
                    //Reduce the time between attacks by 30%.
                    buffATK += 0.3f;
                    SetStat();
                }
                break;
            case 6:
                {
                    //Increase size by 25%. Increase damage by 30%.
                    BuffWeaponSizeByPersent(0.25f);
                    buffATK += 0.3f;
                    SetStat();
                }
                break;
            case 7:
                {
                    //Throw 3 bombs.
                    numberBombDrop = 3;
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
