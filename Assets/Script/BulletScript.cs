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
        Destroy(gameObject, timeAutoDestroy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Physics2D.OverlapCircle(transform.position, 0.3f, LayerMask.GetMask("Monster")))
        {
            animator.SetBool("isExplode", true);
            ZombieScript z=collision.GetComponent<ZombieScript>();
            if(z != null)
            {
                MessengerSystem.instance.DmgPopUp(dmgBullet.ToString(), z.transform.position,isCrit);
                bool isDead= z.ZombieTakeDmg(dmgBullet);
                if (isDead)
                {
                    GameObject.Find("Player").GetComponent<CharacterInfo_1>().KilledMonster();
                }
                Rigidbody2D rb=GetComponent<Rigidbody2D>();
                rb.velocity = Vector3.zero;
                Destroy(gameObject, 0.4f);
            }
           
        }
    }
}
