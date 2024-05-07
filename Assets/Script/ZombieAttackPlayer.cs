using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollowPlayer : MonoBehaviour
{
    //Vị trí của player
    [SerializeField] Transform targetDestination;
    Rigidbody2D rigidbody2D;
    //Nhận biết tấn công player 
    GameObject targetGameObject;

    [SerializeField] int hp = 4;

    private void Awake()
    {
        rigidbody2D=GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject == targetGameObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("Attacked player");
    }

    public void ZombieTakeDmg(int dmg)
    {
        hp -= dmg;
        Debug.Log(hp);
        if(hp <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
