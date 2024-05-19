using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Text buffName;
    [SerializeField] Text description;

    public void Set(UpgradeData upgradeData)
    {
        icon.sprite = upgradeData.icon;
        buffName.text = upgradeData.buffName;
        description.text = upgradeData.description;
    }
}
