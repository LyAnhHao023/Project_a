using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsManager : MonoBehaviour
{
    public List<GoodsData> goodsDatas;

    public GameObject goodsPerfab;
    public GameObject goodsTranform;

    GameObject goodsHolder;

    private void Start()
    {
        for (int i = 0; i < goodsDatas.Count; i++)
        {
            goodsHolder = Instantiate(goodsPerfab, goodsTranform.transform);

            goodsDatas[i].acquiced = PlayerPrefs.GetInt(goodsDatas[i].name, -1) == 1 ? true : false;
            goodsDatas[i].level = PlayerPrefs.GetInt(goodsDatas[i].name + "lv", 0);

            goodsHolder.GetComponent<SetItemShop>().Set(goodsDatas[i]);
        }
    }
}
