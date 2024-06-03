using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class effectSkillOdleHero : MonoBehaviour
{
    CharacterStats characterStats;
    int dmgBase;
    float timer;

    Vector3 playerTranform;

    public void SetDmg(CharacterStats stats,int dmg, Vector3 player)
    {
        characterStats= stats;
        dmgBase = dmg;
        playerTranform = player;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 0.5f;

            EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
            if (enemy != null)
            {
                if (!enemy.GetComponent<Collider2D>().isTrigger)
                {
                    Vector2 knockbackDirection = (enemy.transform.position - playerTranform).normalized;
                    enemy.Knockback(knockbackDirection, 6);
                }

                bool isCrit = Random.value * 100 < characterStats.crit;
                float dmg = isCrit ?
                    (dmgBase + characterStats.strenght) * characterStats.critDmg : (dmgBase + characterStats.strenght);

                MessengerSystem.instance.DmgPopUp(dmg.ToString(), enemy.transform.position, isCrit);

                bool isDead = enemy.EnemyTakeDmg((int)dmg);
                if (isDead)
                {
                    GetComponentInParent<CharacterInfo_1>().KilledMonster();
                }
            }
        }
    }
}
