using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheMoreTheMerrierItemPassive : ItemBase
{
    [SerializeField]
    float timeSpawEnemyMinus=0.2f;
    [SerializeField]
    StageData StageData;
    int monterKilled;

    private void Awake()
    {
        monterKilled = GetComponentInParent<CharacterInfo_1>().numberMonsterKilled;
        GameObject.Find("===SpawEnemy===").GetComponent<SpawEnemy>().reduceTimeSpaw += timeSpawEnemyMinus;
    }

    public override void Update()
    {
        ItemEffect();
    }

    public override void ItemEffect()
    {
        CharacterInfo_1 player = GetComponentInParent<CharacterInfo_1>();
        int kill= player.numberMonsterKilled;
       if (monterKilled < kill)
       {
            int coinAmout = kill - monterKilled;
            monterKilled = kill;
            player.GainCoin(coinAmout);
       }
    }

    public override void SetItemStat()
    {
        switch (level)
        {
            case 1:
                {
                    timeSpawEnemyMinus = 0.2f;
                }
                break;
            case 2:
                {
                    timeSpawEnemyMinus = 0.4f;
                }
                break;
            case 3:
                {
                    timeSpawEnemyMinus = 0.6f;
                }
                break;
            case 4:
                {
                    timeSpawEnemyMinus = 0.8f;
                }
                break;
            case 5:
                {
                    timeSpawEnemyMinus = 1f;
                }
                break;
            case 6:
                {
                    timeSpawEnemyMinus = 1.5f;
                }
                break;
        }
    }
}
