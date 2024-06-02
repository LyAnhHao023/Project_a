using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassOfKnowledgeItem : ItemBase
{
    [SerializeField]
    float expPersent=0.2f;
    CharacterInfo_1 player;

    public override void ItemEffect()
    {
        player.expPercent += expPersent;
    }

    // Start is called before the first frame update
    void Start()
    {
        player=GetComponentInParent<CharacterInfo_1>();
        ItemEffect();
    }
}
