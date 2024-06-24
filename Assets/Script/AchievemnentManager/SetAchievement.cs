using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetArchievement : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Text name;
    [SerializeField] Text description;
    [SerializeField] Text points;
    [SerializeField] GameObject Locker;

    public void Set(ArchievementData archievementData)
    {
        icon.sprite = archievementData.icon;
        name.text = archievementData.achieName;
        description.text = archievementData.description;
        points.text = string.Format("+ {0}", archievementData.points);
        Locker.SetActive(!archievementData.complete);
    }
}
