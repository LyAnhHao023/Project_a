using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetItemShop : MonoBehaviour
{
    [SerializeField] GameObject goodsHolder;
    [SerializeField] Button ButtonHolder;
    [SerializeField] GameObject Locker;
    [SerializeField] Image Icon;
    [SerializeField] Text Level;

    private ShopManager shopManager;
    private SetGoodsInfo goodsInfo;
    GameObject infoHolder;

    GoodsData goods;

    private void Awake()
    {
        shopManager = GameObject.FindGameObjectWithTag("ShopManager").GetComponent<ShopManager>();

        infoHolder = shopManager.goodsInfo();

        goodsInfo = infoHolder.GetComponent<SetGoodsInfo>();
    }

    private void Start()
    {
        ButtonHolder.onClick.AddListener(Onclick);
    }

    public void Set(GoodsData goodsData)
    {
        goods = goodsData;
        Icon.sprite = goodsData.icon;
        Level.text = SetLevelText(goodsData);
        Locker.SetActive(goodsData.level>0?false:true);
    }

    string SetLevelText(GoodsData goods)
    {
        if (goods.level == goods.maxLevel && goods.level == 1)
        {
            return "ACQUIRED";
        }

        if (goods.level == goods.maxLevel)
        {
            return "MAX";
        }

        return string.Format("Lv. {0}", goods.level);
    }

    void Onclick()
    {
        infoHolder.SetActive(true);

        goodsInfo.Set(goods, goodsHolder);
    }
}
