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


    public List<weaponEnquip> weapons_lst=new List<weaponEnquip>(5);

    int i = 0;
    float timer = 10;

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            AddWeapon(ToxinZonesWeapon);
        }
    }

    public void AddWeapon(WeaponData weaponData)
    {
        if (!weapons_lst.Any(w => w.weaponData == weaponData))
        {
            weaponData.stats.level = 1;
            GameObject weaponObject = Instantiate(weaponData.weaponBasePrefab, weaponObjectTranform);
            weaponObject.GetComponent<WeaponBase>().SetData(weaponData);
            weaponEnquip newWeaponEnquip = new weaponEnquip(weaponData, weaponObject);
            weapons_lst.Add(newWeaponEnquip);
        }
        else
        {
            //Do update weapon
        }
    }
}
