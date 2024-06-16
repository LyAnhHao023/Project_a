using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : WeaponBase
{
    [SerializeField]
    GameObject Bullet;

    [SerializeField]
    Transform firePos;

    [SerializeField]
    float bulletForce=1;

    [SerializeField]
    GameObject imgFire;
    [SerializeField]
    GameObject fireEffect;

    CharacterStats characterStats;

    [SerializeField]
    Transform bulletsObject;

    [SerializeField]
    WeaponStats baseStat = new WeaponStats(1,1,1f);

    private void Awake()
    {
        SetCharacterStats();
        bulletsObject = GameObject.Find("BulletsObject").transform;
    }

    public override void Update()
    {
        if(Time.deltaTime != 0)
            RotationGun();
        base.Update();
    }

    private void RotationGun()
    {
        Vector3 mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir=mousePos-transform.position;
        float angle=Mathf.Atan2(lookDir.y,lookDir.x)*Mathf.Rad2Deg;

        Quaternion rotation=Quaternion.Euler(0,0, angle);
        transform.rotation = rotation;
        if(transform.eulerAngles.z>90&& transform.eulerAngles.z < 270)
        {
            transform.localScale=new Vector3(1, -1,1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

    }

    public override void Attack()
    {

        GameObject createBullet = Instantiate(Bullet, firePos.position, Quaternion.identity);
        createBullet.transform.parent = bulletsObject.transform;
        //Set dmg
        bool isCrit = UnityEngine.Random.value * 100 < characterStats.crit;

        float dmg = isCrit ?
                    (weaponStats.dmg + characterStats.strenght) * characterStats.critDmg : (weaponStats.dmg + characterStats.strenght);
        createBullet.GetComponent<BulletScript>().SetDmg((int)dmg,isCrit);
        Rigidbody2D rigidbody2D = createBullet.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);

        //effect gun fire
        Instantiate(imgFire, firePos.position, transform.rotation, transform);
        Instantiate(fireEffect, firePos.position, transform.rotation, transform);
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
