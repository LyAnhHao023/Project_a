using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class AxeWeapon : MonoBehaviour
{
    [SerializeField]

    float timeAttack=4f;

    float timer;

    [SerializeField] GameObject rightAxe;
    [SerializeField] GameObject leftAxe;


    //dmg cua Axe
    [SerializeField]
    private int AxeDmg=1;

    [SerializeField]
    private Vector2 AxeAttackSize=new Vector2(4f,3f);

    playerMove playerMove;

    CharacterStats characterStats;

    public void SetCharacterStats()
    {
        characterStats = GetComponentInParent<CharacterInfo_1>().characterStats;
    }

    private void Awake()
    {
        playerMove = GetComponentInParent<playerMove>();
        characterStats = GetComponentInParent<CharacterInfo_1>().characterStats;
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
        Collider2D[] colliders;
        if (playerMove.scaleX == 1)
        {
            rightAxe.SetActive(true);
            //Lay danh sach thong tin cua vat the ma Axe va cham
            colliders = Physics2D.OverlapBoxAll(rightAxe.transform.position, AxeAttackSize, 0f);
        }
        else
        {
            leftAxe.SetActive(true);
            colliders = Physics2D.OverlapBoxAll(leftAxe.transform.position, AxeAttackSize, 0f);
        }

        //Lay danh sach thong tin cua vat the ma Axe va cham

        if(colliders.Length > 0&&colliders!=null ) 
        {
            ApllyDmg(colliders);
        }

    }

    private void ApllyDmg(Collider2D[] colliders)
    {
        for(int i = 0; i < colliders.Length; i++)
        {
            ZombieScript z = colliders[i].GetComponent<ZombieScript>();
            if(z != null)
            {
                float dmg = UnityEngine.Random.value * 100 < characterStats.crit ?
                    (AxeDmg + characterStats.strenght) * characterStats.critDmg : (AxeDmg + characterStats.strenght);
                bool isDead=z.ZombieTakeDmg((int)dmg);
                if(isDead)
                {
                    GetComponentInParent<CharacterInfo_1>().KilledMonster();
                }

            }
        }
    }
}
