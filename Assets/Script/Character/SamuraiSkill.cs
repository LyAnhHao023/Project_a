using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiSkill : MonoBehaviour
{
    [SerializeField]
    int killToUseSkill = 10;
    [SerializeField]
    int dmgSkill = 20;

    [SerializeField]
    GameObject effectSkillPrefab;

    int currentKill = 0;
    int energy = 0;
    CharacterStats characterStats;

    [SerializeField] float timeToDeActiveSkill = 5f;


    // Update is called once per frame
    void Update()
    {
        int kill = GetComponentInParent<CharacterInfo_1>().numberMonsterKilled;
        energy += kill - currentKill;
        currentKill = kill;

        if (Input.GetKeyDown(KeyCode.Q) && energy >= killToUseSkill)
        {
            energy = 0;
            Skill();
        }

    }

    private void Skill()
    {
        characterStats = GetComponentInParent<CharacterInfo_1>().characterStats;
        effectSkillPrefab.GetComponent<effectSkillOdleHero>().SetDmg(characterStats, dmgSkill, transform.position);
        effectSkillPrefab.SetActive(true);
        Invoke("DeActiveSkil", timeToDeActiveSkill);

    }

    private void DeActiveSkil()
    {
        effectSkillPrefab.SetActive(false);
    }
}