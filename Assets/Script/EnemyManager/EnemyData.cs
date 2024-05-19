using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnenmyStats
{
    public int hp;
    public int dmg;
    public int speed;
    public float timeAttack;

    public EnenmyStats(int hp, int dmg, int speed,float timeAttack)
    {
        this.hp = hp;
        this.dmg = dmg;
        this.speed = speed;
        this.timeAttack = timeAttack;

    }
}

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public EnenmyStats stats;
    public string name;
    public GameObject EnemyBasePrefab;
}
