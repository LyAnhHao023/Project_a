using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRockFallingMap3 : MonoBehaviour
{
    float timer;
    [SerializeField] float timeReFalling;
    [SerializeField] List<GameObject> fallingPrefab=new List<GameObject>();

    private void Start()
    {
        timer = timeReFalling;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer<=0)
        {
            timer = timeReFalling;
            foreach (GameObject item in fallingPrefab)
            {
                item.SetActive(true);
            }

        }
    }
}
