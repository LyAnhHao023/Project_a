using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowHealthItem : ItemBase
{   
    [SerializeField] float time = 0;

    public override void ItemEffect()
    {
        time = GetComponentInParent<CharacterInfo_1>().time;
        switch (level)
        {
            case 1:
                {
                    if (time >= 0.1)
                    {
                        GetComponentInParent<CharacterInfo_1>().SlowHealthDe(1);
                        time = 0;
                    }
                }
                break;
            case 2:
                {
                    if (time >= 0.2)
                    {
                        GetComponentInParent<CharacterInfo_1>().SlowHealthDe(1);
                        time = 0;
                    }
                }
                break;
            case 3:
                {
                    if (time >= 0.3)
                    {
                        GetComponentInParent<CharacterInfo_1>().SlowHealthDe(1);
                        time = 0;
                    }
                }
                break;
            case 4:
                {
                    if (time >= 0.5)
                    {
                        GetComponentInParent<CharacterInfo_1>().SlowHealthDe(1);
                        time = 0;
                    }
                }
                break;
        }
    }

    public override void Update()
    {
        ItemEffect();
    }
}
