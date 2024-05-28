using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheMoreTheMerrierItemPassive : ItemBase
{
    [SerializeField]
    float timeSpawEnemyMinus=0.5f;
    int monterKilled;

    private void Awake()
    {
        monterKilled = GetComponentInParent<CharacterInfo_1>().numberMonsterKilled;
        GameObject.Find("===SpawEnemy===").GetComponent<SpawEnemy>().spawTime -= timeSpawEnemyMinus;
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
            player.GainCoin(coinAmout);
       }
    }
}
