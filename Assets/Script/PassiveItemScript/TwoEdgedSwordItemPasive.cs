using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoEdgedSwordItemPasive : ItemBase
{
    [SerializeField]
    int HpMinusPersecons=2;
    [SerializeField]
    float dmgBuff=0.2f;
    [SerializeField]
    float timeMinusHp=2;
    float timer;

    CharacterInfo_1 player;

    private void Awake()
    {
        player = GetComponentInParent<CharacterInfo_1>();
        player.attackPercent += dmgBuff;
        player.statUpdate();
    }

    public override void Update()
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

    public override void SetItemStat()
    {
        switch (level)
        {
            case 1:
                {
                    dmgBuff = 0.2f;
                    HpMinusPersecons = 2;
                    timeMinusHp = 2;
                }
                break;
            case 2:
                {
                    dmgBuff += 0.3f;
                    HpMinusPersecons = 3;
                    timeMinusHp = 2;
                }
                break;
            case 3:
                {
                    dmgBuff += 0.2f;
                    HpMinusPersecons = 3;
                    timeMinusHp = 2.5f;
                }
                break;
            case 4:
                {
                    dmgBuff += 0.1f;
                    HpMinusPersecons = 2;
                    timeMinusHp = 3f;
                }
                break;
            case 5:
                {
                    dmgBuff += 0.2f;
                    HpMinusPersecons = 2;
                    timeMinusHp = 4f;
                }
                break;
        }
    }
}
