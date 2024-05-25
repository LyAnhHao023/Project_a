using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MagicicanBossScript : EnemyBase
{
    [SerializeField]
    //Nhận biết tấn công player 
    public GameObject targetGameObject;

    [SerializeField]
    GameObject SkillTelePrefab;

    [SerializeField]
    Transform firePos;
    [SerializeField]
    GameObject AttackPrefab;

    float timer;
    [SerializeField]
    float timeSkillTele=5;
    float timerTele;

    Animator animator;

    int rotasionChange = 0;

    [SerializeField]
    Vector2 areaAttack = new Vector2(3, 3);

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
    int numberDropCoins;
    [SerializeField]
    int numberDropExp;

    GameObject ParentDropItem;

    bool isUseSkill=false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void SetTarget(GameObject GameObject)
    {
        targetGameObject = GameObject;
        gameObject.GetComponent<AIPath>().maxSpeed = enemyStats.speed;
        SkillTelePrefab.GetComponent<MagicicanSkill>().SetDmg(enemyStats.dmg, targetGameObject);
    }

    public override void SetParentDropItem(GameObject gameObject)
    {
        ParentDropItem = gameObject;
    }

    private void Update()
    {
        GetComponent<SpriteRenderer>().flipX = transform.position.x < targetGameObject.transform.position.x;

        timerTele -= Time.deltaTime;

        if(isUseSkill==false&& timerTele < 0)
        {
            isUseSkill = true;
            animator.SetTrigger("Tele");
            animator.SetBool("isReady", false);
            gameObject.GetComponent<AIPath>().canMove = false;
            Invoke("StartSkillTele", 0.4f);
        }

        if(timerTele > 0)
        {
            Collider2D[] Collider2D = Physics2D.OverlapBoxAll(transform.position, areaAttack, 0f);
            GameObject targetObject = Collider2D.Where(c => c.gameObject == targetGameObject).FirstOrDefault()?.gameObject;
            if (targetObject != null)
            {
                GetComponent<AIPath>().canMove = false;

                timer -= Time.deltaTime;
                if (timer < 0)
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

    }

    private void StartSkillTele()
    {
        animator.SetBool("Warning", true);
        GetComponent<Collider2D>().enabled = false;
        transform.position=targetGameObject.transform.position;
        Invoke("EndSkill", 2f);
    }

    private void EndSkill()
    {
        animator.SetBool("Warning", false);
        GetComponent<Collider2D>().enabled = true;
        SkillTelePrefab.SetActive(true);
        timerTele = timeSkillTele;
        isUseSkill = false;
    }

    private void Attack()
    {
        animator.SetBool("isReady", true);
        GameObject createSkill = Instantiate(AttackPrefab, firePos.position, Quaternion.identity);
        createSkill.transform.parent = GameObject.Find("===ObjectDrop===").transform;
        createSkill.GetComponent<MagicicanAttackScript>().SetDmg(enemyStats.dmg);
        createSkill.transform.localScale = transform.localScale;

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
            GetComponent<Rigidbody2D>().simulated = false;
            animator.SetBool("Dead", true);
            Destroy(gameObject, 1f);
            Drop();
            return true;
        }
        return false;
    }

    private void Drop()
    {
        Transform health = Instantiate(HealthPrefab).transform;
        health.position = RandomPositionDrops(transform.position);
        health.transform.parent = ParentDropItem.transform;

        Transform chest = Instantiate(ChestPrefab).transform;
        chest.position = RandomPositionDrops(transform.position);

        for (int i = 0; i <= numberDropCoins; i++)
        {
            GameObject createCoins = Instantiate(CoinPrefab);
            createCoins.transform.position = RandomPositionDrops(transform.position);
            createCoins.GetComponent<CoinScript>().SetPlayer(targetGameObject);
            createCoins.transform.parent = ParentDropItem.transform;
        }
        for (int i = 0; i <= numberDropExp; i++)
        {
            GameObject createExpRed = Instantiate(ExpRedPrefab);
            createExpRed.transform.position = RandomPositionDrops(transform.position);
            createExpRed.GetComponent<CapsuleExp>().SetPlayer(targetGameObject);
            createExpRed.transform.parent = ParentDropItem.transform;
        }
    }

    public Vector3 RandomPositionDrops(Vector3 center)
    {
         float radius = 5f;
        // Tạo một vector direction random
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        // Thêm vector direction vào vị trí trung tâm
        Vector3 randomPosition = center + randomDirection;

        return randomPosition;
    }
}
