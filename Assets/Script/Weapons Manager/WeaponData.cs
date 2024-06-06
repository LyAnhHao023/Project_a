using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponStats
{
    public int dmg;
    public int level;
    public float timeAttack;

    public WeaponStats(int damage,int level, float timeAttack)
    {
        this.dmg = damage;
        this.level = level;
        this.timeAttack = timeAttack;
    }
}
[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string name;
    public WeaponStats stats;
    public GameObject weaponBasePrefab;
    public List<UpdateInfo> weaponUpdateInfos;
}
