using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchievementManager : MonoBehaviour
{
    [SerializeField] GameObject ArchievementPanel;

    public List<ArchievementData> archievementDatas;

    public GameObject archievementPefab;
    public GameObject archievementTranform;

    GameObject archievementHolder;

    public int totalPoints;

    private void Start()
    {
        for (int i = 0; i < archievementDatas.Count; i++)
        {
            archievementHolder = Instantiate(archievementPefab, archievementTranform.transform);

            archievementDatas[i].complete = PlayerPrefs.GetInt(archievementDatas[i].achieName, -1) == 1 ? true : false;

            archievementHolder.GetComponent<SetArchievement>().Set(archievementDatas[i]);

            if (archievementDatas[i].complete)
            {
                totalPoints += archievementDatas[i].points;

                PlayerPrefs.SetInt("TotalPoints", totalPoints);
                PlayerPrefs.Save();
            }
        }
    }
}
