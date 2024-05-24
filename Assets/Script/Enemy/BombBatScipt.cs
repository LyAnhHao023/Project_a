using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBatScipt : EnemyBase
{

    [SerializeField]
    //Nhận biết tấn công player 
    public GameObject targetGameObject;

    [SerializeField]
    GameObject warningZone;
    [SerializeField]
    GameObject exploder;

    float timeAttack;

    Animator animator;

    int rotasionChange = 0;

    [SerializeField]
    Vector2 areaAttack=new Vector2(3,3);

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
        foreach (var item in Collider2D)
        {
            if(item.gameObject == targetGameObject)
            {
                Attack();
            }
        }

    }

    public void ApllyDmgToPlayer()
    {
        targetGameObject.GetComponent<CharacterInfo_1>().TakeDamage(enemyStats.dmg);
    }

    private void Attack()
    {
        GetComponent<Rigidbody2D>().mass = 500;
        GetComponent<AIPath>().canMove = false;
        warningZone.SetActive(true);
        Invoke("Explosion",2f);
        animator.SetBool("isReady", true);
    }

    private void Explosion()
    {
        GetComponent<SpriteRenderer>().enabled=false;
        warningZone.SetActive(false);
        exploder.SetActive(true);
    }

    public override bool EnemyTakeDmg(int dmg)
    {
        enemyStats.hp -= dmg;
        animator.SetTrigger("Hit");
        if (enemyStats.hp <= 0)
        {
            DestroyBombBat();
            return true;
        }
        return false;
    }

    public void DestroyBombBat()
    {
        Destroy(gameObject,0.4f);
        Invoke("Drop", 0.4f);
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
