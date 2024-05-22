using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcoEffect : MonoBehaviour
{
    float timer;
    [SerializeField]
    float timeSpaws=0.5f;
    [SerializeField]
    float timeLifeEcho=0.3f;

    public GameObject echo;

    private void Update()
    {
        if (timer < 0)
        {
            timer = timeSpaws;
            GameObject echoObject= Instantiate(echo,transform.position,Quaternion.Euler(0,0,Random.value*360));
            echoObject.transform.parent = transform;
            Destroy(echoObject, timeLifeEcho);
        }
        else
        {
            timer-=Time.deltaTime;
        }
    }
}
