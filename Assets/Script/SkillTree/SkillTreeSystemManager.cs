using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeSystemManager : MonoBehaviour
{
    [SerializeField] WizardSkillTreeManager wizardSkillTree;
    [SerializeField] WarriorSkillTreeManager warriorSkillTree;
    [SerializeField] AssassinSkillTreeManager assassinSkillTree;

    private SkillTree skillTree;

    public void SetSkillTree(SkillTree skillTree)
    {
        this.skillTree = skillTree;
    }

    public void Set()
    {
        switch (skillTree.type)
        {
            case 1:
                {
                    warriorSkillTree.Set(skillTree.level);
                }
                break;
            case 2:
                {
                    wizardSkillTree.Set(skillTree.level);
                }
                break;
            case 3:
                {
                    assassinSkillTree.Set(skillTree.level);
                }
                break;
        }
    }
}
