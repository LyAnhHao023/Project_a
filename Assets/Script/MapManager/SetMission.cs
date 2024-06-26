using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMission : MonoBehaviour
{
    [SerializeField] Text _missionInfo;
    [SerializeField] Text MissionProgress;

    public void Set(MissionInfo missionInfo)
    {
        _missionInfo.text = missionInfo.decription;

        if (missionInfo.completed)
        {
            _missionInfo.color = Color.green;
            MissionProgress.color = Color.green;
        }

        if (missionInfo.missionType.ToString() == "HP")
            MissionProgress.text = "(0/1)";
        if (missionInfo.missionType.ToString() == "Kill")
            MissionProgress.text = string.Format("(0/{0})", missionInfo.num);
    }

    public void SetProgress(MissionInfo missionInfo, bool missionFail = false)
    {
        if(missionFail)
        {
            _missionInfo.color = Color.red;
            MissionProgress.color = Color.red;
        }

        if (missionInfo.missionType.ToString() == "HP")
            MissionProgress.text = "(0/1)";
        if (missionInfo.missionType.ToString() == "Kill")
            MissionProgress.text = string.Format("(0/{0})", missionInfo.num);
    }
}
