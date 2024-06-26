using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLightningMap1 : MonoBehaviour
{
    [SerializeField]
    GameObject Lightning;

    [SerializeField]
    GameObject LightBeforLightning;

    [SerializeField]
    float timeLightning = 7f;

    float timer = 7;

    // Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;
        if (timer <= 1.5)
        {
            LightBeforLightning.SetActive(true);
            StartCoroutine(LightningActive());
        }
    }

    private IEnumerator LightningActive()
    {
        yield return new WaitForSeconds(1.5f);
        Lightning.SetActive(true);
        timer = timeLightning;
    }
}
