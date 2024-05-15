using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    int dmgBullet=2;
    [SerializeField]
    float timeAutoDestroy=10f;
    Animator animator;
    public void SetDmg(int dmg)
    {
        dmgBullet= dmg;
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
                z.ZombieTakeDmg(dmgBullet);
                Rigidbody2D rb=GetComponent<Rigidbody2D>();
                rb.velocity = Vector3.zero;
                Destroy(gameObject, 0.4f);
            }
           
        }
    }
}
