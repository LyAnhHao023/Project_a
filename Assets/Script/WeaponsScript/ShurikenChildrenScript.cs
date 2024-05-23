﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenChildrenScript : MonoBehaviour
{
    float radius = 0f; // Bán kính xoáy ốc
    [SerializeField]
    float speed = 10f; // Tốc độ xoáy ốc
    [SerializeField]
    float deactivateDistance = 8f; // Khoảng cách khi vật thể sẽ tự động tắt

    private int angleRos = 0;
    private float angle = 0f;

    [SerializeField]
    Transform ShurikenParent;

    private void OnEnable()
    {
        angleRos = 0;
        angle = 0f;
        radius = 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponentInParent<ShurikenScript>().ApllyDmg(collision);
    }

    void Update()
    {
        radius += 0.005f;
        angleRos += 5;
        // Tính toán vị trí mới của vật thể dựa trên góc và bán kính xoáy ốc
        float x = ShurikenParent.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        float y = ShurikenParent.position.y+ Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
        transform.position = new Vector3(x, y, 0);
        transform.rotation = Quaternion.Euler(0, 0, angleRos);

        // Tăng góc để di chuyển vật thể
        angle += speed * Time.deltaTime;

        // Nếu khoảng cách vượt quá giá trị deactivateDistance, deactivate vật thể
        if (radius >= deactivateDistance)
        {
            gameObject.SetActive(false);
        }
    }
}