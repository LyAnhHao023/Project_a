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
    [SerializeField] GameObject AnvilUpdatePrefab;

    [SerializeField] float TimeBoxDrop = 15f;
    [SerializeField] float TimeAnvilUpdateDrop = 20f;

    [SerializeField]
    Timer timerScript;

    float timerBoxDrop;
    float timerAnvilUpdateDrop;

    int eventIndex=0;

    private void Start()
    {
        timerBoxDrop = TimeBoxDrop;
        timerAnvilUpdateDrop= TimeAnvilUpdateDrop;
    }

    private void Update()
    {
        timerBoxDrop -= Time.deltaTime;
        timerAnvilUpdateDrop -= Time.deltaTime;

        if (timerBoxDrop <= 0)
        {
            timerBoxDrop = TimeBoxDrop;
            SpawBoxDrop();
        }

        if (timerAnvilUpdateDrop <= 0)
        {
            timerAnvilUpdateDrop = TimeAnvilUpdateDrop;
            SpawAnvilUpdateDrop();
        }

        if (eventIndex >= StageData.stageEvents.Count) { return; }

        if (timerScript.elapsedTime > StageData.stageEvents[eventIndex].Time)
        {
            SpawEnemy();
            eventIndex++;
        }

    }

    private void SpawAnvilUpdateDrop()
    {
        GameObject anvil= Instantiate(AnvilUpdatePrefab);
        anvil.transform.SetParent(GameObject.Find("===ObjectDrop===").transform);
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
