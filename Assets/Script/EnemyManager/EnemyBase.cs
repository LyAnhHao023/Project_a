using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public EnemyData enemyData;

    public EnenmyStats enemyStats;

    bool isKnockback=false;
    private Rigidbody2D rb;
    public virtual void SetData(EnemyData enemy)
    {
        enemyData = enemy;
        enemyStats = new EnenmyStats(enemy.stats.hp, enemy.stats.dmg, enemy.stats.speed, enemy.stats.timeAttack,
                                     enemy.stats.chanceDropCoin,enemy.stats.chanceDropHeath,enemy.stats.chanceDropExp);
        rb=GetComponent<Rigidbody2D>();
    }

    public abstract void SetTarget(GameObject GameObject);
    public abstract void SetParentDropItem(GameObject gameObject);

    public void IncreaseDecreaseSpeed(int speed)
    {
        enemyStats.speed += speed;
        gameObject.GetComponent<AIPath>().maxSpeed = enemyStats.speed;
    }
    public abstract bool EnemyTakeDmg(int dmg);

    public void Knockback(Vector2 direction, float force)
    {
        if (!isKnockback)
        {
            isKnockback = true;
            GetComponent<AIPath>().canMove = false;
            rb.AddForce(direction * force, ForceMode2D.Impulse);

            // Sau một khoảng thời gian, reset lại trạng thái isKnockback
            Invoke("ResetKnockback", 0.5f);
        }
    }

    private void ResetKnockback()
    {
        isKnockback = false;
        GetComponent<AIPath>().canMove = true;
        rb.velocity = Vector2.zero;

    }

}
