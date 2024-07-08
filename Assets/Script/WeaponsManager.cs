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
    float timer = 10;
    float time = 10;

    private void Update()
    {
        if(timer <= 0)
        {
            foreach (var item in weapons_lst)
            {
                CheckCollab(item);
            }

            timer = time;
        }
    }

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
                    if(!item.weaponObject.GetComponent<WeaponBase>().weaponData.maxed)
                    {
                        item.weaponObject.GetComponent<WeaponBase>().LevelUp();
                        break;
                    }
                    else
                    {
                        item.weaponObject.GetComponent<WeaponBase>().OverLevelUp();
                    }

                    if(item.weaponObject.GetComponent<WeaponBase>().weaponData.maxed)
                    {
                        CheckCollab(item);
                    }

                    break;
                }
            }
        }
    }

    public void RemoveWeapon(WeaponData weaponData)
    {
        weaponEnquip removeItem = null;
        for (int i = 0; i < weapons_lst.Count; i++)
        {
            if (weapons_lst[i].weaponData == weaponData)
            {
                Destroy(weapons_lst[i].weaponObject);
                removeItem = weapons_lst[i];
                break;
            }
        }

        weapons_lst.Remove(removeItem);
    }

    private void CheckCollab(weaponEnquip weapon)
    {
        foreach (var item in weapons_lst)
        {
            if(item.weaponObject.GetComponent<WeaponBase>().weaponStats.level == 7)
            {
                if (item.weaponData == weapon.weaponData.weaponColabData)
                {
                    stageEventManager.SetColab();
                    break;
                }
            }
        }
    }
}
