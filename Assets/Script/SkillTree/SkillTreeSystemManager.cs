using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeSystemManager : MonoBehaviour
{
    [SerializeField] WizardSkillTreeManager wizardSkillTree;
    [SerializeField] WarriorSkillTreeManager warriorSkillTree;
    [SerializeField] AssassinSkillTreeManager assassinSkillTree;

    [SerializeField] GameObject InfoHolder;

    private SkillTree skillTree;

    public void SetSkillTree(SkillTree skillTree)
    {
        this.skillTree = skillTree;
        InfoHolder.SetActive(false);
    }

    public void Set()
    {
        switch (skillTree.type)
        {
            case 1:
                {
                    warriorSkillTree.Set(skillTree.level);
                    wizardSkillTree.Set(0);
                    assassinSkillTree.Set(0);
                }
                break;
            case 2:
                {
                    warriorSkillTree.Set(0);
                    wizardSkillTree.Set(skillTree.level);
                    assassinSkillTree.Set(0);
                }
                break;
            case 3:
                {
                    warriorSkillTree.Set(0);
                    wizardSkillTree.Set(0);
                    assassinSkillTree.Set(skillTree.level);
                }
                break;
        }
    }
}
