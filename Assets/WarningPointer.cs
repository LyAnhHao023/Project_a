using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningPointer : MonoBehaviour
{
    private Vector3 targetPos;
    [SerializeField]
    GameObject pointerGO;
    float borderSize = 30f;
    float timeLife;

    public void SetTargetAndTimeLife(Vector3 target,float time)
    {
        targetPos = target;
        timeLife = time;
        Destroy(gameObject, timeLife);
    }

    private void Update()
    {
        Vector3 targetPosScreenPoint = Camera.main.WorldToScreenPoint(targetPos);
        bool isOffScreen = targetPosScreenPoint.x <= borderSize || targetPosScreenPoint.x >= Screen.width - borderSize || targetPosScreenPoint.y <= borderSize || targetPosScreenPoint.y >= Screen.height - borderSize;

        if (isOffScreen)
        {
            Vector3 cappedTargetScreenPos = targetPosScreenPoint;
            if (cappedTargetScreenPos.x <= borderSize) cappedTargetScreenPos.x = borderSize;
            if (cappedTargetScreenPos.x >= Screen.width - borderSize) cappedTargetScreenPos.x = Screen.width - borderSize;
            if (cappedTargetScreenPos.y <= borderSize) cappedTargetScreenPos.y = borderSize;
            if (cappedTargetScreenPos.y >= Screen.height - borderSize) cappedTargetScreenPos.y = Screen.height - borderSize;

            Vector3 pointerWorldPos = Camera.main.ScreenToWorldPoint(cappedTargetScreenPos);
            pointerGO.transform.position = pointerWorldPos;
        }
        else
        {
            pointerGO.transform.position = targetPos;
        }

    }
}
