﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AnvilUpdate : MonoBehaviour
{
    [SerializeField]
    GameObject PointerOJ;

    [SerializeField] Vector2 spawArea;

    MenuManager menuManager;
    GameObject menuObject;

    private void Start()
    {
        Destroy(gameObject, 15f);

        Transform playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 position = CreateRandomPosition();
        position += playerPos.position;
        while (IsObstacle(position))
        {
            position = CreateRandomPosition();
            position += playerPos.position;
        }

        transform.position = position;

        PointerOJ.GetComponent<Window_pointer>().SetTarget(new Vector3(transform.position.x, transform.position.y+1,0));
        menuObject = GameObject.FindGameObjectWithTag("MenuManager");
        menuManager = menuObject.GetComponent<MenuManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterInfo_1 player=collision.GetComponent<CharacterInfo_1>();
        if (player != null)
        {
            Debug.Log("TAKE");
            menuManager.GetComponentInParent<MenuManager>().AnvilUpgradeScene();
            //do somthing............
        }
    }

    private Vector3 CreateRandomPosition()
    {
        Vector3 position = new Vector3(0, 0, 0);
        float value = Random.value > 0.5f ? -1 : 1;
        if (Random.value > 0.5)
        {
            position.x = Random.Range(-spawArea.x, spawArea.x);
            position.y = spawArea.y * value;
        }
        else
        {
            position.y = Random.Range(-spawArea.y, spawArea.y);
            position.x = spawArea.x * value;
        }

        return position;
    }

    //Kiểm tra xem tại vị trí có vật cản hay không
    public bool IsObstacle(Vector3 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, new Vector3(0, 0, 1));
        if (hit.collider != null)
        {
            return hit.collider.gameObject.layer == 6;
        }
        else
        {
            return false;
        }
    }
}