using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMisstion : MonoBehaviour
{
    [SerializeField] Text missionName;
    [SerializeField] Text missionProgress;

    public void Set(MissionInfo missionInfo)
    {
        if (missionInfo.missionType.ToString() == "HP")
            missionProgress.text = "(0/1)";
        if (missionInfo.missionType.ToString() == "Kill")
            missionProgress.text = string.Format("0/{0}", missionInfo.num);

        missionName.text = missionInfo.missionName;
    }

    public void SetProgress(MissionInfo missionInfo)
    {
        if (missionInfo.missionType.ToString() == "HP")
            missionProgress.text = "(0/1)";
        if (missionInfo.missionType.ToString() == "Kill")
            missionProgress.text = string.Format("0/{0}", missionInfo.num);
    }
}
