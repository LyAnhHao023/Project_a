using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField]
    GameObject Bullet;

    [SerializeField]
    Transform firePos;
    [SerializeField]
    float timeFire=0.2f;
    float timer;
    [SerializeField]
    float bulletForce=1;
    [SerializeField]
    GameObject BulletsObject;
    [SerializeField]
    int dmgBullet=1;

    [SerializeField]
    GameObject imgFire;
    [SerializeField]
    GameObject fireEffect;


    playerMove playerMove;
    CharacterStats characterStats;

    public void SetCharacterStats()
    {
        characterStats = GetComponentInParent<CharacterInfo_1>().characterStats;
    }

    private void Awake()
    {
        playerMove = GetComponentInParent<playerMove>();
        characterStats = GetComponentInParent<CharacterInfo_1>().characterStats;
    }
    private void Update()
    {
        RotationGun();
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = timeFire;
            FireBullet();
        }
    }

    private void FireBullet()
    {
        GameObject createBullet=Instantiate(Bullet,firePos.position,Quaternion.identity);
        createBullet.transform.parent = BulletsObject.transform;
        //Set dmg
        float dmg = UnityEngine.Random.value * 100 < characterStats.crit ?
                    (dmgBullet + characterStats.strenght) * characterStats.critDmg : (dmgBullet + characterStats.strenght);
        createBullet.GetComponent<BulletScript>().SetDmg((int)dmg);
        Rigidbody2D rigidbody2D=createBullet.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);

        GameObject createImgFire = Instantiate(imgFire, firePos.position, transform.rotation,transform);
        GameObject createFireEffect = Instantiate(fireEffect, firePos.position, transform.rotation, transform);
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
}
