using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoEdgedSwordItemPasive : ItemBase
{
    [SerializeField]
    int HpMinusPersecons=2;
    [SerializeField]
    float dmgBuff=2;
    [SerializeField]
    float timeMinusHp=2;
    float timer;

    CharacterInfo_1 player;

    private void Awake()
    {
        player = GetComponentInParent<CharacterInfo_1>();
        //player.
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ItemEffect();
            timer = timeMinusHp;
        }
    }
    public override void ItemEffect()
    {
        player.TakeDamage(HpMinusPersecons);
    }
}
