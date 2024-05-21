using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] Text coinText;

    int totalCoin;

    private void Awake()
    {
        totalCoin = PlayerPrefs.GetInt("Coins", 0);
        coinText.text = totalCoin.ToString();
    }
}
