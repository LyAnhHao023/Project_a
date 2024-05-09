using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    [SerializeField]
    //Nhận biết tấn công player 
    GameObject targetGameObject;

    [SerializeField] int hp = 4;

    playerMove playerMove;

    int zombieDmg = 1;

    [SerializeField]
    float cdAttack=0.5f;

    float timeAttack;

    Animator animator;

    private void Awake()
    {
        playerMove = GetComponent<playerMove>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        timeAttack -= Time.deltaTime;
        if (collision.gameObject == targetGameObject&& timeAttack <= 0)
        {
            Attack();
        }
    }

    private void Attack()
    {
        
        timeAttack = cdAttack;
        targetGameObject.GetComponent<HealthTest>().TakeDamage(zombieDmg);
    }

    public void ZombieTakeDmg(int dmg)
    {
        hp -= dmg;
        animator.SetTrigger("Hit");
        Debug.Log(hp);
        if (hp <= 0)
        {
            gameObject.GetComponent<AIPath>().canMove=false;
            animator.SetBool("Dead", true);
            Invoke("DestroyZombie", 1);
        }
    }

    private void DestroyZombie()
    {
        Destroy(gameObject);
    }
}
