using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponData weaponData;

    public WeaponStats weaponStats;
    float timer=0;



    public virtual void Update()
    {
        timer-=Time.deltaTime;
        if (timer < 0)
        {
            timer = weaponStats.timeAttack;
            Attack();
        }
    }

    public virtual void SetData(WeaponData wd)
    {
        weaponData = wd;
        weaponStats = new WeaponStats(wd.stats.dmg,wd.stats.level,wd.stats.timeAttack);
    }
    public abstract void Attack();

    public abstract void SetCharacterStats();
}
