using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgMessengerScript : MonoBehaviour
{
    [SerializeField]
    float timeLife = 0.8f;
    float timer;

    private void OnEnable()
    {
        timer = timeLife;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
