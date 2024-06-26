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
    [SerializeField]
    WeaponData WallSpikeWeapon;
    [SerializeField]
    WeaponData HolyBeamPrefab;


    public List<weaponEnquip> weapons_lst=new List<weaponEnquip>(5);

    int i = 0;
    float timer = 5;

    /*private void Start()
    {
        AddWeapon(HolyBeamPrefab);
    }*/

    //private void Update()
    //{
    //    timer-=Time.deltaTime;
    //    if (timer < 0&&i==0)
    //    {
    //        i++;
    //        weapons_lst.First().weaponObject.GetComponent<WeaponBase>().LevelUp();
    //        weapons_lst.First().weaponObject.GetComponent<WeaponBase>().LevelUp();
    //        weapons_lst.First().weaponObject.GetComponent<WeaponBase>().LevelUp();
    //        weapons_lst.First().weaponObject.GetComponent<WeaponBase>().LevelUp();
    //        weapons_lst.First().weaponObject.GetComponent<WeaponBase>().LevelUp();
    //        weapons_lst.First().weaponObject.GetComponent<WeaponBase>().LevelUp();
    //        weapons_lst.First().weaponObject.GetComponent<WeaponBase>().LevelUp();
    //    }
    //}

    public void AddWeapon(WeaponData weaponData)
    {
        if (!weapons_lst.Any(w => w.weaponData == weaponData))
        {
            GameObject weaponObject = Instantiate(weaponData.weaponBasePrefab, weaponObjectTranform);
            weaponObject.GetComponent<WeaponBase>().SetData(weaponData);
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
                    item.weaponObject.GetComponent<WeaponBase>().LevelUp();
                    break;
                }
            }
        }
    }
}
