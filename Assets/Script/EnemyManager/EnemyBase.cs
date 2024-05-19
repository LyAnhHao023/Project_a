using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public EnemyData enemyData;

    public EnenmyStats enemyStats;


    public virtual void SetData(EnemyData enemy)
    {
        enemyData = enemy;
        enemyStats = new EnenmyStats(enemy.stats.hp, enemy.stats.dmg, enemy.stats.speed, enemy.stats.timeAttack);
    }

    public abstract void SetTarget(GameObject GameObject);
    public abstract void SetParentDropItem(GameObject gameObject);
    public abstract bool EnemyTakeDmg(int dmg);
}
