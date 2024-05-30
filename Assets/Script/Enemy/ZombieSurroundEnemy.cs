using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSurroundEnemy : EnemyBase
{
    public GameObject targetGameObject;

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
    public override bool EnemyTakeDmg(int dmg) => throw new System.NotImplementedException();

    public void DestroyParent()
    {
        Destroy(gameObject, 1f);
    }

    public void Attack()
    {
        targetGameObject.GetComponent<CharacterInfo_1>().TakeDamage(enemyStats.dmg);
    }

    public override void SetParentDropItem(GameObject gameObject)
    {
        ParentDropItem = gameObject;
    }

    public override void SetTarget(GameObject GameObject)
    {
        targetGameObject = GameObject;
        transform.position = targetGameObject.transform.position;
    }

    public void Drop(Vector3 posDrop)
    {
        if (Random.value * 100 <= chanceDropHeath)
        {
            Transform health = Instantiate(HealthPrefab).transform;
            health.position = posDrop;
            health.transform.parent = ParentDropItem.transform;
        }

        //Transform chest = Instantiate(ChestPrefab).transform;
        //chest.position = transform.position;

        if (Random.value * 100 <= chanceDropExpRed)
        {
            GameObject createExpRed = Instantiate(ExpRedPrefab);
            createExpRed.transform.position = posDrop;
            createExpRed.GetComponent<CapsuleExp>().SetPlayer(targetGameObject);
            createExpRed.transform.parent = ParentDropItem.transform;
        }
        else
        {
            GameObject createGreen = Instantiate(ExpGreenPrefab);
            createGreen.transform.position = posDrop;
            createGreen.GetComponent<CapsuleExp>().SetPlayer(targetGameObject);
            createGreen.transform.parent = ParentDropItem.transform;
        }

        if (Random.value * 100 <= chanceDropCoin)
        {
            GameObject createCoins = Instantiate(CoinPrefab);
            createCoins.transform.position = posDrop;
            createCoins.GetComponent<CoinScript>().SetPlayer(targetGameObject);
            createCoins.transform.parent = ParentDropItem.transform;
        }
    }
}
