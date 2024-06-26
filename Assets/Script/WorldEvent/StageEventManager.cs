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

    [SerializeField] EnemyData BoxDropPrefab;

    [SerializeField] float TimeBoxDrop = 15f;

    [SerializeField]
    Timer timerScript;

    float timer;

    int eventIndex=0;

    private void Start()
    {
        timer = TimeBoxDrop;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = TimeBoxDrop;
            SpawBoxDrop();
        }

        if (eventIndex >= StageData.stageEvents.Count) { return; }

        if (timerScript.elapsedTime > StageData.stageEvents[eventIndex].Time)
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

    private void SpawBoxDrop()
    {
        spawEnemyManager.CreateNewEnemy(BoxDropPrefab, false);
    }
}
