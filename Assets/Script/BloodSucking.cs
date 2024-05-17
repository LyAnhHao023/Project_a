using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSucking : ItemBase
{
    [SerializeField]
    int heath=5;
    [SerializeField]
    int level=1;

    int monsterKilled=0;

    public override void ItemEffect()
    {
        int updateMonsterKilled =  GetComponentInParent<CharacterInfo_1>().numberMonsterKilled;
        if (monsterKilled < updateMonsterKilled)
        {
            monsterKilled = updateMonsterKilled;
            GetComponentInParent<CharacterInfo_1>().HealthByNumber(heath);
        }
    }

    public override void Update()
    {
        ItemEffect();
    }
}
