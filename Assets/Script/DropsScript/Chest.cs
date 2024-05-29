using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField]
    GameObject PointerPrefab;
    [SerializeField]
    Transform PointerPos;

    GameObject PointerOJ;

    private void Awake()
    {
        PointerOJ=Instantiate(PointerPrefab);
        PointerOJ.transform.parent = PointerPos.transform;
        PointerOJ.GetComponent<Window_pointer>().SetTarget(PointerPos.position);
    }
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
