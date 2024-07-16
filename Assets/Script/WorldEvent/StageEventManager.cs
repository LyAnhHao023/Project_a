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
    [SerializeField] GameObject AnvilColabPrefab;
    [SerializeField] EnemyData HaoLyPrefab;

    [SerializeField] float TimeBoxDrop = 15f;
    [SerializeField] float TimeAnvilUpdateDrop = 20f;
    [SerializeField] float TimeAnvilColabDrop = 60f;
    [SerializeField] float timeSpawHaoLy = 180f;
    [SerializeField] float chanceSpawHaoLy = 40f;
    bool isSpawed=false;

    [SerializeField]
    Timer timerScript;

    float timerBoxDrop;
    float timerAnvilUpdateDrop;
    float timerAnvilColabDrop;

    int eventIndex=0;

    int totalColab = 0;

    public void SetColab()
    {
        totalColab++;
    }

    private void Start()
    {
        timerBoxDrop = TimeBoxDrop;
        timerAnvilUpdateDrop= TimeAnvilUpdateDrop;
        timerAnvilColabDrop = TimeAnvilColabDrop;
    }

    private void Update()
    {
        timerBoxDrop -= Time.deltaTime;
        timerAnvilUpdateDrop -= Time.deltaTime;

        if (totalColab > 0)
        {
            timerAnvilColabDrop -= Time.deltaTime;

            if(timerAnvilColabDrop <= 0)
            {
                totalColab -= 1;
                timerAnvilColabDrop = TimeAnvilColabDrop;
                SpawAnvilColabDrop();
            }
        }

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

        if (timerScript.elapsedTime >= timeSpawHaoLy&& !isSpawed)
        {
            isSpawed = true;
            if(UnityEngine.Random.value*100<=chanceSpawHaoLy)
            {
                spawEnemyManager.CreateNewEnemy(HaoLyPrefab,false);
            }
        }

    }

    private void SpawAnvilUpdateDrop()
    {
        GameObject anvil= Instantiate(AnvilUpdatePrefab);
        anvil.transform.SetParent(GameObject.Find("===ObjectDrop===").transform);
    }

    private void SpawAnvilColabDrop()
    {
        GameObject anvil = Instantiate(AnvilColabPrefab);
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
