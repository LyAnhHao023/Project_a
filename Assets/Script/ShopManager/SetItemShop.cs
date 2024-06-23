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

    int currentLevel;

    private void Awake()
    {
        shopManager = GameObject.FindGameObjectWithTag("ShopManager").GetComponent<ShopManager>();

        infoHolder = shopManager.goodsInfo();

        goodsInfo = infoHolder.GetComponent<SetGoodsInfo>();
    }

    /*private void Update()
    {
        if(currentLevel != goods.level)
            Level.text = string.Format("Lv. {0}", goods.level);
    }*/

    public void Set(GoodsData goodsData)
    {
        goods = goodsData;
        Icon.sprite = goodsData.icon;
        if (!goodsData.acquiced)
            goodsData.level = 0;
        currentLevel = goodsData.level;
        Level.text = string.Format("Lv. {0}", goodsData.level);
        Locker.SetActive(!goodsData.acquiced);

        ButtonHolder.onClick.AddListener(Onclick);
    }

    void Onclick()
    {
        infoHolder.SetActive(true);

        goodsInfo.Set(goods, goodsHolder);
    }
}
