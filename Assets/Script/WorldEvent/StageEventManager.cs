using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [SerializeField]
    StageData StageData;

    [SerializeField]
    SpawEnemy spawEnemyManager;

    [SerializeField]
    Timer timer;

    int eventIndex=0;

    private void Update()
    {
        if (eventIndex >= StageData.stageEvents.Count) { return; }

        if (timer.elapsedTime > StageData.stageEvents[eventIndex].Time)
        {
            SpawEnemy();
            eventIndex++;
        }
    }

    private void SpawEnemy()
    {
        StageEvent currentEvent= StageData.stageEvents[eventIndex];
        spawEnemyManager.AddGroupToSpaw(currentEvent.enemySpawData, currentEvent.countEnemy, currentEvent.isBoss);

        if(currentEvent.isRepeatedEvent)
        {
            spawEnemyManager.AddRepeatedSpaw(currentEvent);
        }
    }
}
