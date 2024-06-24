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

            goodsDatas[i].level = PlayerPrefs.GetInt(goodsDatas[i].goodsName + "lv", 0);

            goodsHolder.GetComponent<SetItemShop>().Set(goodsDatas[i]);
        }
    }
}
