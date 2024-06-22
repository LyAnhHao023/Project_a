using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmySkill : MonoBehaviour
{
    [SerializeField]
    GameObject effectSkillPrefab;
    [SerializeField]
    float timeDeActiveSkill = 0.4f;

    float timer = 0;
    CharacterInfo_1 player;

    private void Start()
    {
        player = GetComponentInParent<CharacterInfo_1>();
    }


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q) && timer <= 0)
        {
            timer = player.skillInfor.cdSkill;
            Skill();
        }

    }

    private void Skill()
    {
        effectSkillPrefab.SetActive(true);
        StartCoroutine(DeActiveSkill());

    }

    private IEnumerator DeActiveSkill()
    {
        yield return new WaitForSeconds(timeDeActiveSkill);
        effectSkillPrefab.SetActive(false);
    }
}
