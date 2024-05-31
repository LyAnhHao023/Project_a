using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyShieldItem : ItemBase
{
    CharacterInfo_1 player;
    [SerializeField]
    int shieldPlus;
    [SerializeField]
    float timeRecoveryShield;
    float timer;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponentInParent<CharacterInfo_1>();
        player.PlusMaxSheild(shieldPlus);
        timer = timeRecoveryShield;
    }

    private void SetAnimationOff()
    {
        animator.SetBool("Broken", false);
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public override void Update()
    {
        if (player.shieldCurrentValue <= 0&& animator.enabled==true)
        {
            animator.SetBool("Broken", true);
            Invoke("SetAnimationOff",0.4f);
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }

        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = timeRecoveryShield;
            ItemEffect();
        }
    }

    public override void ItemEffect()
    {
        player.ShieldRecovery(shieldPlus);
    }
}
