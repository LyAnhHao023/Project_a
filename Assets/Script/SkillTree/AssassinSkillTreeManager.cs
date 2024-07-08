using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssassinSkillTreeManager : MonoBehaviour
{
    public List<Skill> skillList;
    public List<SetSkillInfoHolder> skillInfoHolderList;

    [SerializeField] Text SkillName;
    [SerializeField] Image SkillIcon;
    [SerializeField] Text SkillDescription;
    [SerializeField] GameObject SkillContainer;
    [SerializeField] GameObject ClassLocker;

    int currentLevel;

    public void Set(int level)
    {
        currentLevel = level;

        for (int i = 0; i < level; i++)
        {
            skillList[i].isUpgrade = true;
        }

        if (level > 0)
        {
            ClassLocker.SetActive(false);
        }
        else
        {
            ClassLocker.SetActive(true);
        }
    }

    public void SetInfo()
    {
        SkillContainer.SetActive(skillList[currentLevel].isUpgrade);
        SkillName.text = skillList[currentLevel].skillName;
        SkillDescription.text = skillList[currentLevel].skillDescription;
    }
}
