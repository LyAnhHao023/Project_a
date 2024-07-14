using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] Text coinText;
    [SerializeField] Text pointsText;
    [SerializeField] GameObject goodsInfoHolder;

    [SerializeField] GameObject skillTreeSystemManager;

    public GameObject goodsInfo()
    {
        return goodsInfoHolder;
    }

    public GameObject SkillTree()
    {
        return skillTreeSystemManager;
    }

    int totalCoin;
    int totalPoint;

    private void Awake()
    {
        PlayerPrefs.SetInt("Coins", 10000);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        Set();
    }

    public void Set()
    {
        totalCoin = PlayerPrefs.GetInt("Coins", 0);
        coinText.text = totalCoin.ToString();
        totalPoint = PlayerPrefs.GetInt("TotalPoints", 0);
        pointsText.text = string.Format("{0} PT", totalPoint);
    }
}
