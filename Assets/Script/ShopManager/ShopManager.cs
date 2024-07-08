using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] Text coinText;
    [SerializeField] Text pointsText;
    [SerializeField] GameObject goodsInfoHolder;

    public GameObject goodsInfo()
    {
        return goodsInfoHolder;
    }

    int totalCoin;
    int totalPoint;

    private void Awake()
    {
        PlayerPrefs.SetInt("Coins", 100000);
        PlayerPrefs.Save();
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
