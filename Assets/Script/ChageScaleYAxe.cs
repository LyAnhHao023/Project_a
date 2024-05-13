using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageScaleYAxe : MonoBehaviour
{
    playerMove playerMove;

    private void Awake()
    {
        playerMove = GetComponentInParent<playerMove>();
    }

    private void Update()
    {
        if(playerMove.scaleX==1) 
        {
            transform.localScale = new Vector3(-1, -1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
