using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemsEnquip
{
    public ItemsData itemData;
    public GameObject itemObject;

    public ItemsEnquip(ItemsData itemData, GameObject itemObject)
    {
        this.itemData = itemData;
        this.itemObject = itemObject;
    }
}

public class PassiveItemsManager : MonoBehaviour
{
    [SerializeField] 
    Transform itemObjectTranform;

    //Danh sach ItemsPassive Prefab
    [SerializeField]
    ItemsData bloodSuckingPrefab;
    [SerializeField]
    ItemsData increaseHitSpeed;
    [SerializeField]
    ItemsData bigWeapons;
    [SerializeField]
    ItemsData TheMoreTheMerrier;
    [SerializeField]
    ItemsData TwoEdgedSword;


    public List<ItemsEnquip> itemsEquip_lst = new List<ItemsEnquip>(5);

    int i = 0;

    /*private void Start()
    {
        AddItem(bloodSuckingPrefab);
    }*/

    private void Update()
    {
        if (gameObject.GetComponentInParent<CharacterInfo_1>().numberMonsterKilled == 5&&i==0)
        {
            i++;
            AddItem(TwoEdgedSword);
            Debug.Log("trang bi thanh cong");
        }else if(gameObject.GetComponentInParent<CharacterInfo_1>().numberMonsterKilled == 10 && i == 1)
        {
            i++;
            AddItem(TheMoreTheMerrier);
        }
    }

    public void AddItem(ItemsData itemData)
    {
        if(!itemsEquip_lst.Any(i => i.itemData == itemData))
        {
            itemData.level = 1;
            GameObject newItem=Instantiate(itemData.ItemBasePrefab, itemObjectTranform);
            ItemsEnquip newItemsEnquip = new ItemsEnquip(itemData,newItem);
            itemsEquip_lst.Add(newItemsEnquip);
        }
        else
        {
            //do update
        }
    }

}
