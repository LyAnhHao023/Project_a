using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ZombieScript : MonoBehaviour
{
    [SerializeField]
    //Nhận biết tấn công player 
    public GameObject targetGameObject;

    [SerializeField] int hp = 4;

    [SerializeField]
    int zombieDmg = 1;

    [SerializeField]
    float cdAttack=0.5f;

    float timeAttack;

    Animator animator;

    int rotasionChange=0;

    [SerializeField]
    [Range(0f,10f)] float chanceDropHeath=1f;

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
    [Range(0f, 10f)] float chanceDropExpRed=1f;
    [SerializeField]
    [Range(0f, 20f)] float chanceDropCoin = 1f;

    GameObject ParentDropItem;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetTarget(GameObject GameObject)
    {
        targetGameObject = GameObject;
    }

    public void SetParentDropItem(GameObject gameObject)
    {
        ParentDropItem = gameObject;
    }

    private void Update()
    {
        rotasionChange = transform.position.x > targetGameObject.transform.position.x ? 180 : 0;
        animator.transform.rotation = Quaternion.Euler(0, rotasionChange, 0);
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
        targetGameObject.GetComponent<CharacterInfo_1>().TakeDamage(zombieDmg);
    }

    public bool ZombieTakeDmg(int dmg)
    {
        hp -= dmg;
        animator.SetTrigger("Hit");
        if (hp <= 0)
        {
            gameObject.GetComponent<AIPath>().canMove=false;
            Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D>();
            rigidbody.simulated = false;
            animator.SetBool("Dead", true);
            DestroyZombie();
            return true;
        }
        return false;
    }

    private void DestroyZombie()
    {
        Destroy(gameObject,1f);
        ChanceDrop();
    }

    private void ChanceDrop()
    {
        if (Random.value * 100 <= chanceDropHeath)
        {
            Transform health = Instantiate(HealthPrefab).transform;
            health.position = transform.position;
            health.transform.parent = ParentDropItem.transform;
        }

        //Transform chest = Instantiate(ChestPrefab).transform;
        //chest.position = transform.position;

        if(Random.value * 100 <= chanceDropExpRed)
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

        if (Random.value * 100 <= chanceDropCoin)
        {
            GameObject createCoins = Instantiate(CoinPrefab);
            createCoins.transform.position = transform.position;
            createCoins.GetComponent<CoinScript>().SetPlayer(targetGameObject);
            createCoins.transform.parent = ParentDropItem.transform;
        }
    }
}
