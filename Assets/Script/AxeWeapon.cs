using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeWeapon : MonoBehaviour
{
    [SerializeField]

    float timeAttack=4f;

    float timer;

    [SerializeField] GameObject rightAxe;
    [SerializeField] GameObject leftAxe;

    //Bien nhan gia tri vi tri cua player
    playerMove playerMove;

    //dmg cua Axe
    [SerializeField]
    private int AxeDmg=2;

    [SerializeField]
    private readonly Vector2 AxeAttackSize=new Vector2(4f,3f);

    private void Awake()
    {
        playerMove=GetComponentInParent<playerMove>();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            Attack();
            
        }
    }

    private void Attack()
    {
        timer = timeAttack;
        rightAxe.SetActive(true);

        //Lay danh sach thong tin cua vat the ma Axe va cham
        Collider2D[] colliders =  Physics2D.OverlapBoxAll(rightAxe.transform.position, AxeAttackSize, 0f);

        ApllyDmg(colliders);

    }

    private void ApllyDmg(Collider2D[] colliders)
    {
        for(int i = 0; i < colliders.Length; i++)
        {
            ZombieScript z = colliders[i].GetComponent<ZombieScript>();
            if(z != null)
            {
                colliders[i].GetComponent<ZombieScript>().ZombieTakeDmg(AxeDmg);

            }
        }
    }
}
