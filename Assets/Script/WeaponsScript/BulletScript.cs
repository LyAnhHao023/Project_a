using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    int dmgBullet=2;
    [SerializeField]
    float timeAutoDestroy=10f;
    Animator animator;
    bool isCrit;
    public void SetDmg(int dmg, bool isCrit)
    {
        dmgBullet= dmg;
        this.isCrit = isCrit;
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        transform.localScale = GameObject.Find("Weapons").transform.localScale;
        Destroy(gameObject, timeAutoDestroy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        EnemyBase enemy= collision.gameObject.GetComponent<EnemyBase>();
        if(enemy!=null)
        {
            animator.SetBool("isExplode", true);
            MessengerSystem.instance.DmgPopUp(dmgBullet.ToString(), enemy.transform.position, isCrit);
            bool isDead = enemy.EnemyTakeDmg(dmgBullet);
            if (isDead)
            {
                GameObject.Find("Player").GetComponent<CharacterInfo_1>().KilledMonster();
            }
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.zero;
            Destroy(gameObject, 0.4f);

        }
    }
}
