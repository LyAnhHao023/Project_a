using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class weaponEnquip
{
    public WeaponData weaponData;
    public GameObject weaponObject;

    public weaponEnquip(WeaponData weaponData, GameObject weaponObject)
    {
        this.weaponData = weaponData;
        this.weaponObject = weaponObject;
    }
}

public class WeaponsManager : MonoBehaviour
{
    [SerializeField]
    Transform weaponObjectTranform;

    //Danh sach vu khi
    [SerializeField]
    WeaponData gunWeapon;
    [SerializeField]
    WeaponData axeWeapon;
    [SerializeField]
    WeaponData bombWeapon;
    [SerializeField]
    WeaponData ToxinZonesWeapon;
    [SerializeField]
    WeaponData ShurikenWeapon;
    [SerializeField]
    WeaponData BazokaWeapon;


    public List<weaponEnquip> weapons_lst=new List<weaponEnquip>(5);

    //int i = 0;
    //float timer = 10;

    private void Start()
    {
        AddWeapon(BazokaWeapon);
    }

    public void AddWeapon(WeaponData weaponData)
    {
        if (!weapons_lst.Any(w => w.weaponData == weaponData))
        {
            GameObject weaponObject = Instantiate(weaponData.weaponBasePrefab, weaponObjectTranform);
            weaponObject.GetComponent<WeaponBase>().SetBaseStat(weaponData);
            weaponEnquip newWeaponEnquip = new weaponEnquip(weaponData, weaponObject);
            weapons_lst.Add(newWeaponEnquip);
        }
        else
        {
            //Do update weapon
            foreach(var item in  weapons_lst)
            {
                if(item.weaponData == weaponData)
                {
                    item.weaponObject.GetComponent<WeaponBase>().weaponStats.dmg = weaponData.stats.dmg;
                    item.weaponObject.GetComponent<WeaponBase>().weaponStats.level = weaponData.stats.level;
                    item.weaponObject.GetComponent<WeaponBase>().weaponStats.timeAttack = weaponData.stats.timeAttack;
                    break;
                }
            }
        }
    }
}
