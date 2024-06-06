using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOfMoneyItem : MonoBehaviour
{
    [SerializeField]
    int persentDropCoinBuffInt;
    [SerializeField]
    float persentAttackBuffFloat;

    CharacterInfo_1 player;
    int coinCurrent;
    private void Start()
    {
        player = GetComponentInParent<CharacterInfo_1>();
        coinCurrent = player.coins;
        GameObject.Find("===SpawEnemy===").GetComponent<SpawEnemy>().PlusOrMinusEnemyStats(0,0,0,0, persentDropCoinBuffInt, 0,0);
    }

    private void FixedUpdate()
    {
        if (coinCurrent < player.coins)
        {
            int persentBuff=player.coins-coinCurrent;
            player.attackPercent += persentBuff * persentAttackBuffFloat;
            coinCurrent = player.coins;
        }
    }
}
