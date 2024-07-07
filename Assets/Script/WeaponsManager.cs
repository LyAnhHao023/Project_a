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

    [SerializeField] StageEventManager stageEventManager;

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
    [SerializeField]
    WeaponData WindMagicPrefab;
    [SerializeField]
    WeaponData SuperShurikenPrefab;
    [SerializeField]
    WeaponData SuperHolyBeamPrefab;
    [SerializeField]
    WeaponData SuperWallSpikePrefab;


    public List<weaponEnquip> weapons_lst=new List<weaponEnquip>(5);

    int i = 0;
    float timer = 5;

    private void Start()
    {
        AddWeapon(SuperWallSpikePrefab);
    }

    //private void Update()
    //{
    //    timer -= Time.deltaTime;
    //    if (timer < 0 && i == 0)
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
                    if(item.weaponObject.GetComponent<WeaponData>().stats.level < 7)
                    {
                        item.weaponObject.GetComponent<WeaponBase>().LevelUp();
                    }
                    else
                    {

                    }

                    if(item.weaponObject.GetComponent<WeaponData>().stats.level == 7)
                    {
                        CheckCollab(item);
                    }

                    break;
                }
            }
        }
    }

    private void CheckCollab(weaponEnquip weapon)
    {
        foreach (var item in weapons_lst)
        {
            if(item.weaponData == weapon.weaponData.weaponColabData && item.weaponObject.GetComponent<WeaponData>().stats.level == 7)
            {
                stageEventManager.SetColab();
                break;
            }
        }
    }
}
