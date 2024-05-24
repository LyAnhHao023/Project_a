﻿using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MagicanEnemyScript : EnemyBase
{
    [SerializeField]
    //Nhận biết tấn công player 
    public GameObject targetGameObject;

    [SerializeField]
    Transform firePos;
    [SerializeField]
    GameObject SkillPrefab;

    float timer;

    Animator animator;

    int rotasionChange = 0;

    [SerializeField]
    Vector2 areaAttack = new Vector2(3, 3);

    [SerializeField]
    [Range(0f, 10f)] float chanceDropHeath = 1f;

    [SerializeField]
    GameObject HealthPrefab;
    [SerializeField]
    GameObject ChestPrefab;
    [SerializeField]
    GameObject ExpGreenPrefab;
    [SerializeField]
    GameObject ExpRedPrefab;
    [SerializeField]
    GameObject CoinPrefab;
    [SerializeField]
    [Range(0f, 10f)] float chanceDropExpRed = 1f;
    [SerializeField]
    [Range(0f, 20f)] float chanceDropCoin = 1f;

    GameObject ParentDropItem;

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    public override void SetTarget(GameObject GameObject)
    {
        targetGameObject = GameObject;
        gameObject.GetComponent<AIPath>().maxSpeed = enemyStats.speed;
    }

    public override void SetParentDropItem(GameObject gameObject)
    {
        ParentDropItem = gameObject;
    }

    private void Update()
    {
        rotasionChange = transform.position.x > targetGameObject.transform.position.x ? 0 : 180;
        animator.transform.rotation = Quaternion.Euler(0, rotasionChange, 0);

        Collider2D[] Collider2D = Physics2D.OverlapBoxAll(transform.position, areaAttack, 0f);
        GameObject targetObject = Collider2D.Where(c => c.gameObject == targetGameObject).FirstOrDefault()?.gameObject;
        if(targetObject != null)
        {
            GetComponent<AIPath>().canMove = false;

            timer-=Time.deltaTime;
            if(timer < 0)
            {
                timer = enemyStats.timeAttack;
                Attack();
            }

        }
        else
        {
            GetComponent<AIPath>().canMove = true;
            animator.SetBool("isReady", false);
        }

    }

    private void Attack()
    {
        animator.SetBool("isReady",true);
        GameObject createSkill = Instantiate(SkillPrefab, firePos.position, Quaternion.identity);
        createSkill.transform.parent = GameObject.Find("===ObjectDrop===").transform;
        createSkill.GetComponent<MagicicanAttackScript>().SetDmg(enemyStats.dmg);

        Rigidbody2D rb = createSkill.GetComponent<Rigidbody2D>();
        Vector3 direction = (targetGameObject.transform.position - firePos.position).normalized;
        rb.AddForce(direction * 10f, (ForceMode2D)ForceMode.Impulse);
    }

    public override bool EnemyTakeDmg(int dmg)
    {
        enemyStats.hp -= dmg;
        animator.SetTrigger("Hit");
        if (enemyStats.hp <= 0)
        {
            GetComponent<AIPath>().canMove = false;
            GetComponent<Rigidbody2D>().simulated=false;
            animator.SetBool("Dead", true);
            Destroy(gameObject,1f);
            Invoke("Drop", 0.4f);
            return true;
        }
        return false;
    }

    private void Drop()
    {
        if (UnityEngine.Random.value * 100 <= chanceDropHeath)
        {
            Transform health = Instantiate(HealthPrefab).transform;
            health.position = transform.position;
            health.transform.parent = ParentDropItem.transform;
        }

        //Transform chest = Instantiate(ChestPrefab).transform;
        //chest.position = transform.position;

        if (UnityEngine.Random.value * 100 <= chanceDropExpRed)
        {
            GameObject createExpRed = Instantiate(ExpRedPrefab);
            createExpRed.transform.position = transform.position;
            createExpRed.GetComponent<CapsuleExp>().SetPlayer(targetGameObject);
            createExpRed.transform.parent = ParentDropItem.transform;
        }
        else
        {
            GameObject createGreen = Instantiate(ExpGreenPrefab);
            createGreen.transform.position = transform.position;
            createGreen.GetComponent<CapsuleExp>().SetPlayer(targetGameObject);
            createGreen.transform.parent = ParentDropItem.transform;
        }

        if (UnityEngine.Random.value * 100 <= chanceDropCoin)
        {
            GameObject createCoins = Instantiate(CoinPrefab);
            createCoins.transform.position = transform.position;
            createCoins.GetComponent<CoinScript>().SetPlayer(targetGameObject);
            createCoins.transform.parent = ParentDropItem.transform;
        }
    }
}
