using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowHealthItem : ItemBase
{
    [SerializeField] float time;
    [SerializeField] int healthDe;
    CharacterInfo_1 player;

    private void Start()
    {
        player = GetComponentInParent<CharacterInfo_1>();
    }

    public override void ItemEffect()
    {
        player.SlowHealthDe(healthDe);
    }

    public override void Update()
    {
        time += Time.deltaTime;

        switch (level)
        {
            case 1:
                {
                    if (time >= 0.3)
                    {
                        healthDe = 1;
                        time = 0;

                        ItemEffect();
                    }
                }
                break;
            case 2:
                {
                    if (time >= 0.4)
                    {
                        healthDe = 1;
                        time = 0;

                        ItemEffect();
                    }
                }
                break;
            case 3:
                {
                    if (time >= 0.5)
                    {
                        healthDe = 2;
                        time = 0;

                        ItemEffect();
                    }
                }
                break;
            case 4:
                {
                    if (time >= 0.5)
                    {
                        healthDe = 1;
                        time = 0;

                        ItemEffect();
                    }
                }
                break;
        }
    }
}
