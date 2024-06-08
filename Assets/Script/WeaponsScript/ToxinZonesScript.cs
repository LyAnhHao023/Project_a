using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxinZonesScript : WeaponBase
{
    CharacterStats characterStats;
    Dictionary<EnemyBase, bool> slowedEnemies = new Dictionary<EnemyBase, bool>();

    [SerializeField]
    int speedSlow=1;

    Vector3 WeaponLocalScale;

    [SerializeField]
    WeaponStats baseStat = new WeaponStats(1, 1, 1f);

    private void Awake()
    {
        SetCharacterStats();
        Vector3 vt = GameObject.Find("Weapons").transform.localScale;
        WeaponLocalScale = vt;
        SetRadiusEffect(WeaponLocalScale.x);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase enemy= collision.gameObject.GetComponent<EnemyBase>();
        if (enemy!=null)
        {
            if (!slowedEnemies.ContainsKey(enemy))
            {
                enemy.GetComponent<EnemyBase>().IncreaseDecreaseSpeed(-speedSlow);
                slowedEnemies.Add(enemy, true);
            }
        }
    }

    private void ApllyDmg(EnemyBase enemy)
    {
        bool isCrit = UnityEngine.Random.value * 100 < characterStats.crit;
        float dmg = isCrit ?
            (weaponStats.dmg + characterStats.strenght) * characterStats.critDmg : (weaponStats.dmg + characterStats.strenght);

        PostDmg((int)dmg, enemy.transform.position, isCrit);

        bool isDead = enemy.EnemyTakeDmg((int)dmg);
        if (isDead)
        {
            GetComponentInParent<CharacterInfo_1>().KilledMonster();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
        if (enemy!=null)
        {
            if (slowedEnemies.ContainsKey(enemy))
            {
                enemy.GetComponent<EnemyBase>().IncreaseDecreaseSpeed(speedSlow);
                slowedEnemies.Remove(enemy);
            }
        }
    }

    public override void Update()
    {
        timer -= Time.deltaTime;
        Transform tr = GameObject.Find("Weapons").transform;

        if(timer < 0)
        {
            timer = weaponStats.timeAttack;
            foreach (var item in slowedEnemies)
            {
                if (item.Value == true)
                {
                    ApllyDmg(item.Key);
                }
            }
        }
        if (tr.localScale != WeaponLocalScale)
        {
            WeaponLocalScale = tr.localScale;
            SetRadiusEffect(WeaponLocalScale.x);
        }
    }

    private void SetRadiusEffect(float x)
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ParticleSystem.ShapeModule shape = ps.shape;
        shape.radius = x*3.5f;//3 la radius mac dinh cua effect
    }

    public override void Attack()
    {
        
    }

    public override void SetCharacterStats()
    {
        characterStats = GetComponentInParent<CharacterInfo_1>().characterStats;
    }

    public override WeaponStats GetBaseStat()
    {
        return baseStat;
    }
}
