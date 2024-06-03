using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OdleHeroSkill : MonoBehaviour
{
    [SerializeField]
    int killToUseSkill = 10;
    [SerializeField]
    int dmgSkill=20;

    [SerializeField]
    GameObject effectSkillPrefab;

    int currentKill=0;
    int energy = 0;
    CharacterStats characterStats;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        int kill = GetComponentInParent<CharacterInfo_1>().numberMonsterKilled;
        energy += kill - currentKill;
        currentKill = kill;

        if (Input.GetKeyDown(KeyCode.Q)&&energy>=killToUseSkill)
        {
            energy = 0;
            Skill();
        }

    }

    private void Skill()
    {
        animator.SetBool("Skill",true);
        characterStats = GetComponentInParent<CharacterInfo_1>().characterStats;
        effectSkillPrefab.GetComponent<effectSkillOdleHero>().SetDmg(characterStats,dmgSkill,transform.position);
        effectSkillPrefab.SetActive(true);
        Invoke("DeActiveSkil", 2f);

    }

    private void DeActiveSkil()
    {
        animator.SetBool("Skill", false);
        effectSkillPrefab.SetActive(false);
    }
}
