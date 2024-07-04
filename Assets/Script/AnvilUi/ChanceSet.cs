using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChanceSet : MonoBehaviour
{
    [SerializeField] GameObject Overlay;
    [SerializeField] Button UpgradeButon;
    [SerializeField] Text Chance;
    [SerializeField] Text Price;
    [SerializeField] CharacterInfo_1 Character;

    int baseUpgradePrice = 100;
    float baseChance = 100f;
    float succesChance;
    int upgradePrice;

    UpgradeData upgradeData;
    bool type;

    float totalWeight;

    List<WeightedItem> items = new List<WeightedItem>
    {
        new WeightedItem(0, 100f), //succes
        new WeightedItem(1, 0f), //fail
    };

    int GetRandomType(List<WeightedItem> items)
    {
        totalWeight = 0;

        foreach (var item in items)
        {
            if (item.active)
                totalWeight += item.weight;
        }

        float randomValue = Random.Range(0, totalWeight);

        float weights = 0f;

        foreach (var item in items)
        {
            weights += item.weight;

            if (randomValue <= weights)
            {
                return item.type;
            }
        }

        return -1;
    }

    void UpdateRate()
    {
        foreach (var item in items)
        {
            switch (item.type)
            {
                case 0:
                    {
                        item.weight = succesChance;
                    }
                    break;
                case 1:
                    {
                        item.weight = 100 - succesChance;
                    }
                    break;
            }
        }
    }

    public void SetUpgrade(UpgradeData data, bool type)//true = weapon, false = item
    {
        upgradeData = data;
        this.type = type;
        upgradePrice = baseUpgradePrice * data.level;
        if (Character.coins < upgradePrice)
            Overlay.SetActive(true);
        else
            Overlay.SetActive(false);
        Price.text = upgradePrice.ToString();
        ChanceCal();
        Chance.text = string.Format("{0}%", succesChance);

        UpgradeButon.onClick.AddListener(Onclick);
    }

    void ChanceCal()
    {
        if(upgradeData.maxed)
        {
            succesChance = baseChance;
        }
        else
        {
            succesChance = baseChance - upgradeData.overLevel * upgradeData.overLevel;
        }

        UpdateRate();
    }

    void Onclick()
    {
        int succesed = GetRandomType(items);

        if(succesed > 0)
        {

        }
        else
        {
            Upgrade(type);
        }
    }

    void Upgrade(bool type)
    {
        Character.AddUpgrade(upgradeData, type);
    }
}
