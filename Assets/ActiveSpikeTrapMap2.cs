using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSpikeTrapMap2 : MonoBehaviour
{
    [SerializeField] GameObject TrapPrefab;
    [SerializeField] float timeCdTrap;
    float timer;

    private void FixedUpdate()
    {
        timer-=Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(timer<=0)
        {
            timer=timeCdTrap;
            TrapPrefab.SetActive(true);
            StartCoroutine(DeActiveTrap());
        }
    }

    private IEnumerator DeActiveTrap()
    {
        yield return new WaitForSeconds(10f);

        TrapPrefab.SetActive(false);
    }
}
