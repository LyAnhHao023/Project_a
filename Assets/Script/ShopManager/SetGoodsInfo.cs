using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SetGoodsInfo : MonoBehaviour
{
    [SerializeField] Image Icon;
    [SerializeField] GameObject Locker;
    [SerializeField] Button button;
    [SerializeField] GameObject buttonOverlay;
    [SerializeField] Text Name;
    [SerializeField] Text Description;
    [SerializeField] Text ButtonText;

    [SerializeField] ShopManager shopManager;

    private GoodsData goodsData;

    SetItemShop goodsHolder;

    int totalCoins;
    int totalPoints;

    private void Awake()
    {
        totalCoins = PlayerPrefs.GetInt("Coins", 0);
        totalPoints = PlayerPrefs.GetInt("TotalPoints", 0);
    }

    void ButtonCheck(GoodsData goods)
    {
        if (totalCoins < goods.price || (goods.name.ToLower() == "army" && totalPoints < goods.price) || goods.level == goods.maxLevel)
        {
            buttonOverlay.SetActive(true);
            button.enabled = false;
        }
        else
        {
            buttonOverlay.SetActive(false);
            button.enabled = true;
        }
    }

    public void Set(GoodsData goods, GameObject goodsHolder = null)
    {
        if(goodsHolder != null)
            this.goodsHolder = goodsHolder.GetComponent<SetItemShop>();

        goodsData = goods;

        SetInfo(goods);

        ButtonText.text = PriceCheck(goods);

        SetNextPrice();

        ButtonCheck(goods);

        button.onClick.AddListener(Onclick);
    }

    public void SetInfo(GoodsData goods)
    {
        Icon.sprite = goods.icon;
        Name.text = goods.name;
        Description.text = goods.description;
        Locker.SetActive(!goods.acquiced);
    }

    string PriceCheck(GoodsData goods)
    {
        if (goods.level == goods.maxLevel)
        {
            return "MAX";
        }

        if(!goods.acquiced)
        {
            return "UNLOCK";
        }

        return goods.levelInfos[goods.level].price.ToString();
    }

    void SetNextPrice()
    {
        PlayerPrefs.SetInt(goodsData.name + "lv", goodsData.level);
        PlayerPrefs.Save();

        if (goodsData.level < goodsData.maxLevel)
            goodsData.price = goodsData.levelInfos[goodsData.level].price;
    }

    void Onclick()
    {
        totalCoins -= goodsData.price;

        if (!goodsData.acquiced)
            goodsData.acquiced = true;

        goodsData.level+=1;
        SetNextPrice();

        SetInfo(goodsData);

        PlayerPrefs.SetInt("Coins", totalCoins);
        PlayerPrefs.Save();

        goodsHolder.Set(goodsData);
        shopManager.Set();
    }
}
