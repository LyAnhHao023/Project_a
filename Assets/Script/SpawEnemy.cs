using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawEnemy : MonoBehaviour
{
    //Danh sach Prefab enemy
    [SerializeField] 
    EnemyData ZombiePrefab;
    [SerializeField] 
    EnemyData ZombieBossPrefab;
    [SerializeField]
    EnemyData BombBatPrefab;
    [SerializeField]
    EnemyData MagicicanPrefab;
    [SerializeField]
    EnemyData MagicicanBossPrefab;
    [SerializeField]
    EnemyData VanmpireGirlPrefab;
    [SerializeField]
    EnemyData GhostPrefab;
    [SerializeField]
    EnemyData ZombieSurroundPrefab;
    [SerializeField]
    EnemyData DragonPrefab;
    [SerializeField]
    EnemyData ZicZigPrefab;
    [SerializeField]
    EnemyData WolfPrefab;

    [SerializeField] public float spawTime;
    [SerializeField] Vector2 spawArea;
    [SerializeField] GameObject player;
    public float timer;
    [SerializeField]
    GameObject ParentDropItem;

    List<EnemyData> lstEnemyPrefab;


    int i = 0;

    private void Start()
    {
        lstEnemyPrefab = new List<EnemyData> { ZombiePrefab, ZombieBossPrefab, BombBatPrefab, MagicicanPrefab, 
            MagicicanBossPrefab, VanmpireGirlPrefab, GhostPrefab,ZombieSurroundPrefab,DragonPrefab,ZicZigPrefab };
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = spawTime;
            CreateNewEnemy(WolfPrefab);
            //i++;
            //if(i%2==0)
            //{

            //}
            //if (i == 5)
            //{
            //    CreateNewEnemy(DragonPrefab);
            //    CreateNewEnemy(ZicZigPrefab);
            //}
        }
    }

    public void PlusOrMinusChanceCoinDropPersent(float persent)
    {
        foreach (var item in lstEnemyPrefab)
        {
            item.stats.chanceDropCoin += persent;
        }
    }

    private void CreateNewEnemy(EnemyData enemy)
    {
        Vector3 position= CreateRandomPosition();
        position += player.transform.position;
        while (IsObstacle(position))
        {
            position = CreateRandomPosition();
            position += player.transform.position;
        }
        GameObject createEnemy=Instantiate(enemy.EnemyBasePrefab);

        createEnemy.GetComponent<EnemyBase>().SetData(enemy);

        createEnemy.transform.position = position;

        createEnemy.GetComponent<EnemyBase>().SetTarget(player);
        createEnemy.GetComponent<EnemyBase>().SetParentDropItem(ParentDropItem);
        createEnemy.transform.parent = transform;
    }

    //Tạo vị trí ngẫu nhiên
    private Vector3 CreateRandomPosition()
    {
        Vector3 position = new Vector3(0, 0, 0);
        float value = Random.value > 0.5f? -1:1;
        if (Random.value > 0.5)
        {
            position.x = Random.Range(-spawArea.x, spawArea.x);
            position.y = spawArea.y*value;
        }
        else
        {
            position.y = Random.Range(-spawArea.y, spawArea.y);
            position.x = spawArea.x * value;
        }

        return position;
    }

    //Kiểm tra xem tại vị trí có vật cản hay không
    public bool IsObstacle(Vector3 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(position,new Vector3(0,0,1));
        if(hit.collider != null)
        {
            return hit.collider.gameObject.layer == 6;
        }
        else
        {
            return false;
        }
    }
}
