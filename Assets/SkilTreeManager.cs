using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilTreeManager : MonoBehaviour
{
    [SerializeField]
    GameObject BigWeaponItemPrefab;

    SkillTree skillTree;

    float healthPercent = 0;
    float attackPercent = 0;
    float speedPercent = 0;
    float critPercent = 0;
    float critDmgPercent = 0;
    float reduceDmgTake = 0;
    float reduceCdSkill = 0;
    float speed;


    // Start is called before the first frame update
    void Start()
    {
        skillTree.SetData(GetComponent<CharacterInfo_1>().skillTree);

        if (skillTree.type == 0) return;
        //chiến binh
        else if (skillTree.type == 1)
        {
            switch (skillTree.level)
            {
                case 1:
                    {
                        healthPercent += 0.02f;
                        break;
                    }
                case 2:
                    {
                        healthPercent += 0.02f;
                        healthPercent += 0.05f;
                        break;
                    }
                case 3:
                    {
                        healthPercent += 0.02f;
                        healthPercent += 0.05f;
                        reduceDmgTake += 0.02f;
                        break;
                    }
                case 4:
                    {
                        healthPercent += 0.02f;
                        healthPercent += 0.05f;
                        reduceDmgTake += 0.02f;
                        attackPercent += 0.05f;
                        break;
                    }
                case 5:
                    {
                        healthPercent += 0.02f;
                        healthPercent += 0.05f;
                        reduceDmgTake += 0.02f;
                        attackPercent += 0.05f;
                        reduceDmgTake += 0.03f;
                        break;
                    }
                case 6:
                    {
                        healthPercent += 0.02f;
                        healthPercent += 0.05f;
                        reduceDmgTake += 0.02f;
                        attackPercent += 0.05f;
                        reduceDmgTake += 0.03f;
                        //Add Item BigWeapon
                        break;
                    }
                case 7:
                    {
                        healthPercent += 0.02f;
                        healthPercent += 0.05f;
                        reduceDmgTake += 0.02f;
                        attackPercent += 0.05f;
                        reduceDmgTake += 0.03f;
                        //Add Item BigWeapon
                        healthPercent += 0.05f;
                        break;
                    }
                case 8:
                    {
                        healthPercent += 0.02f;
                        healthPercent += 0.05f;
                        reduceDmgTake += 0.02f;
                        attackPercent += 0.05f;
                        reduceDmgTake += 0.03f;
                        //Add Item BigWeapon
                        healthPercent += 0.05f;
                        reduceDmgTake += 0.03f;
                        break;
                    }
                case 9:
                    {
                        healthPercent += 0.02f;
                        healthPercent += 0.05f;
                        reduceDmgTake += 0.02f;
                        attackPercent += 0.05f;
                        reduceDmgTake += 0.03f;
                        //Add Item BigWeapon
                        healthPercent += 0.05f;
                        reduceDmgTake += 0.03f;
                        attackPercent += 0.05f;
                        break;
                    }
                case 10:
                    {
                        healthPercent += 0.02f;
                        healthPercent += 0.05f;
                        reduceDmgTake += 0.02f;
                        attackPercent += 0.05f;
                        reduceDmgTake += 0.03f;
                        //Add Item BigWeapon
                        healthPercent += 0.05f;
                        reduceDmgTake += 0.03f;
                        attackPercent += 0.05f;
                        //Add Item heal
                        break;
                    }
            }
        }
        //Pháp sư
        else if (skillTree.type == 2)
        {
            switch (skillTree.level)
            {
                case 1:
                    {
                        reduceCdSkill += 0.02f;
                        break;
                    }
                case 2:
                    {
                        reduceCdSkill += 0.02f;
                        attackPercent += 0.02f;
                        break;
                    }
                case 3:
                    {
                        reduceCdSkill += 0.02f;
                        attackPercent += 0.02f;
                        reduceCdSkill += 0.02f;
                        break;
                    }
                case 4:
                    {
                        reduceCdSkill += 0.02f;
                        attackPercent += 0.02f;
                        reduceCdSkill += 0.02f;
                        attackPercent += 0.03f;
                        break;
                    }
                case 5:
                    {
                        reduceCdSkill += 0.02f;
                        attackPercent += 0.02f;
                        reduceCdSkill += 0.02f;
                        attackPercent += 0.03f;
                        speed += 0.5f;
                        break;
                    }
                case 6:
                    {
                        reduceCdSkill += 0.02f;
                        attackPercent += 0.02f;
                        reduceCdSkill += 0.02f;
                        attackPercent += 0.03f;
                        speed += 0.5f;
                        //Add reduceTimeCD item
                        break;
                    }
                case 7:
                    {
                        reduceCdSkill += 0.02f;
                        attackPercent += 0.02f;
                        reduceCdSkill += 0.02f;
                        attackPercent += 0.03f;
                        speed += 0.5f;
                        //Add reduceTimeCD item
                        reduceCdSkill += 0.05f;
                        break;
                    }
                case 8:
                    {
                        reduceCdSkill += 0.02f;
                        attackPercent += 0.02f;
                        reduceCdSkill += 0.02f;
                        attackPercent += 0.03f;
                        speed += 0.5f;
                        //Add reduceTimeCD item
                        reduceCdSkill += 0.05f;
                        speed += 0.5f;
                        break;
                    }
                case 9:
                    {
                        reduceCdSkill += 0.02f;
                        attackPercent += 0.02f;
                        reduceCdSkill += 0.02f;
                        attackPercent += 0.03f;
                        attackPercent += 0.04f;
                        //Add reduceTimeCD item
                        reduceCdSkill += 0.05f;
                        speed += 0.5f;
                        reduceCdSkill += 0.05f;
                        break;
                    }
                case 10:
                    {
                        reduceCdSkill += 0.02f;
                        attackPercent += 0.02f;
                        reduceCdSkill += 0.02f;
                        attackPercent += 0.03f;
                        attackPercent += 0.04f;
                        //Add reduceTimeCD item
                        reduceCdSkill += 0.05f;
                        attackPercent += 0.05f;
                        reduceCdSkill += 0.05f;
                        //Add Item FlameFoot
                        break;
                    }
            }
        }
        //sát thủ
        else if (skillTree.type == 3)
        {
            switch (skillTree.level)
            {
                case 1:
                    {
                        critPercent += 2f;
                        break;
                    }
                case 2:
                    {
                        critPercent += 2f;
                        critPercent += 3f;
                        break;
                    }
                case 3:
                    {
                        critPercent += 2f;
                        critPercent += 3f;
                        critDmgPercent += 5f;
                        break;
                    }
                case 4:
                    {
                        critPercent += 2f;
                        critPercent += 3f;
                        critDmgPercent += 5f;
                        critPercent += 0.3f;
                        break;
                    }
                case 5:
                    {
                        critPercent += 2f;
                        critPercent += 3f;
                        critDmgPercent += 5f;
                        critPercent += 0.3f;
                        critDmgPercent += 10f;
                        break;
                    }
                case 6:
                    {
                        critPercent += 2f;
                        critPercent += 3f;
                        critDmgPercent += 5f;
                        critPercent += 0.3f;
                        critDmgPercent += 10f;
                        // Add Item buff Crit 
                        break;
                    }
                case 7:
                    {
                        critPercent += 2f;
                        critPercent += 3f;
                        critDmgPercent += 5f;
                        critPercent += 0.3f;
                        critDmgPercent += 10f;
                        // Add Item buff Crit 
                        speed += 0.5f;
                        break;
                    }
                case 8:
                    {
                        critPercent += 2f;
                        critPercent += 3f;
                        critDmgPercent += 5f;
                        critPercent += 0.3f;
                        critDmgPercent += 10f;
                        // Add Item buff Crit 
                        speed += 0.5f;
                        critPercent += 5f;   
                        break;
                    }
                case 9:
                    {
                        critPercent += 2f;
                        critPercent += 3f;
                        critDmgPercent += 5f;
                        critPercent += 0.3f;
                        critDmgPercent += 10f;
                        // Add Item buff Crit 
                        speed += 0.5f;
                        critPercent += 5f;
                        critDmgPercent += 15f;
                        break;
                    }
                case 10:
                    {
                        critPercent += 2f;
                        critPercent += 3f;
                        critDmgPercent += 5f;
                        critPercent += 0.3f;
                        critDmgPercent += 10f;
                        // Add Item buff Crit 
                        speed += 0.5f;
                        critPercent += 5f;
                        critDmgPercent += 15f;
                        //Add miss hit
                        break;
                    }
            }
        }
    }
}
