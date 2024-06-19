using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazoka : WeaponBase
{
    [SerializeField]
    GameObject BulletBazoka;

    [SerializeField]
    Transform firePos;
    [SerializeField]
    GameObject fireEffect;

    [SerializeField]
    float bulletForce = 1;

    CharacterStats characterStats;

    [SerializeField]
    Transform bulletsObject;

    [SerializeField]
    WeaponStats baseStat = new WeaponStats(1, 1, 1f);

    Vector3 weaponSize=Vector3.one;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        SetCharacterStats();
        bulletsObject = GameObject.Find("BulletsObject").transform;
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    public override void Update()
    {
        if (Time.deltaTime != 0)
            RotationGun();
        base.Update();
    }

    private void RotationGun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            spriteRenderer.flipY = true;
            firePos.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            spriteRenderer.flipY = false;
            firePos.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    public override void Attack()
    {

        GameObject createBullet = Instantiate(BulletBazoka, firePos.position, transform.rotation);
        createBullet.transform.localScale = (createBullet.transform.localScale + weaponSize) - Vector3.one;
        createBullet.transform.parent = bulletsObject.transform;
        //Set dmg
        bool isCrit = UnityEngine.Random.value * 100 < characterStats.crit;

        float dmg = isCrit ?
                    (weaponStats.dmg + characterStats.strenght) * characterStats.critDmg : (weaponStats.dmg + characterStats.strenght);
        createBullet.GetComponent<BazokaBullet>().SetDmg((int)dmg, isCrit);
        Rigidbody2D rigidbody2D = createBullet.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);

        //effect gun fire

        fireEffect.SetActive(true);
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
