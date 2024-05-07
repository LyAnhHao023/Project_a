using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterAttacked : MonoBehaviour
{
    [SerializeField] float disableTime=0.8f;
    float timer;

    private void OnEnable()
    {
        timer = disableTime;
    }

    private void LateUpdate()
    {
        timer-= Time.deltaTime;
        if (timer < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
