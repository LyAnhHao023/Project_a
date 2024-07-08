using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarriorSkillTreeManager : MonoBehaviour
{
    public List<Skill> skillList;
    public List<SetSkillInfoHolder> skillInfoHolderList;

    [SerializeField] Text SkillName;
    [SerializeField] Image SkillIcon;
    [SerializeField] Text SkillDescription;

    int currentLevel;

    public void Set(int level)
    {
        for (int i = 0; i < level; i++)
        {
            skillList[i].isUpgrade = true;
        }
    }

    public void SetInfo()
    {
        if (currentLevel != 0)
        {
            SkillName.text = skillList[currentLevel - 1].skillName;
            SkillDescription.text = skillList[currentLevel - 1].skillDescription;
        }
    }
}
