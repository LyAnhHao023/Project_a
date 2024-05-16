using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSucking : MonoBehaviour
{
    [SerializeField]
    int heath=5;
    [SerializeField]
    int level=1;
    [SerializeField]
    int monsterKilled=0;

    private void Update()
    {
        int updateMonsterKilled= GetComponentInParent<CharacterInfo_1>().numberMonsterKilled;
        if (monsterKilled <updateMonsterKilled) 
        {
            monsterKilled = updateMonsterKilled;
            GetComponentInParent<CharacterInfo_1>().HealthByNumber(heath);
        }
    }
}
