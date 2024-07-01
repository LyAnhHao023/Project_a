using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMagicWeapon : WeaponBase
{
    [SerializeField]
    List<GameObject> tornadoList = new List<GameObject>();

    int countLst=0;
    int numActiveTornado = 2;
    int countTornado=0;

    CharacterStats characterStats;

    public override void Attack()
    {
        if (countTornado > 0)
        {
            countTornado --;
            tornadoList[countLst].SetActive(true);

            countLst = countLst + 1 >= tornadoList.Count ? 0 : ++countLst;
        }
    }

    public override void LevelUp()
    {
        throw new System.NotImplementedException();
    }

    public override void SetCharacterStats()
    {
        characterStats = GetComponentInParent<CharacterInfo_1>().characterStats;
    }



    // Start is called before the first frame update
    void Start()
    {
        SetCharacterStats();
        CharacterInfo_1 characterInfo_1 = GetComponentInParent<CharacterInfo_1>();
        BuffWeaponSizeByPersent(characterInfo_1.weaponSize);

        foreach (var item in tornadoList)
        {
            item.GetComponent<TornadoOfWindMagic>().SetData(characterStats, weaponStats);
        }

    }

    // Update is called once per frame
    public override void Update()
    {
        timer-=Time.deltaTime;
        if (timer <= 0)
        {
            timer = weaponStats.timeAttack;
            countTornado+=numActiveTornado;
        }
        Attack();
    }
}
