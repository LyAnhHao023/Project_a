﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldeHeroSkill : MonoBehaviour
{
    
    [SerializeField]
    GameObject effectSkillPrefab;

    SkillCooldownUI skillCooldownUI;

    Animator animator;

    float timer =0;
    SkillInfo skillInfor;
    CharacterStats characterStats;
    private void Start()
    {
        skillCooldownUI = GameObject.FindGameObjectWithTag("SkillCooldown").GetComponent<SkillCooldownUI>();
        animator = GetComponent<Animator>();
        skillInfor=GetComponentInParent<CharacterInfo_1>().skillInfor;
        characterStats = GetComponentInParent<CharacterInfo_1>().characterStats;

        skillCooldownUI.SetSkillInfo(skillInfor);
    }


    // Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q)&&timer<=0)
        {
            timer = skillInfor.cdSkill;
            skillCooldownUI.SetCooldown(timer);
            Skill();
        }

    }

    private void Skill()
    {
        animator.SetBool("Skill",true);
        effectSkillPrefab.GetComponent<effectSkillOdleHero>().SetDmg(characterStats, skillInfor.strenght, transform.position);
        effectSkillPrefab.SetActive(true);
        Invoke("DeActiveSkil", 2f);

    }

    private void DeActiveSkil()
    {
        animator.SetBool("Skill", false);
        effectSkillPrefab.SetActive(false);
    }
}
