using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMove player = collision.GetComponent<playerMove>();
        if (player != null)
        {
            Debug.Log("Open Chest!!!");
            DestroyChest();
        }
    }

    public void DestroyChest()
    {
        Destroy(gameObject);
    }
}
