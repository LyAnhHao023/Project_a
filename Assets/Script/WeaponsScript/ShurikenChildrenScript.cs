﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenChildrenScript : MonoBehaviour
{
    float radius = 0f; // Bán kính xoáy ốc
    [SerializeField]
    float speed = 10f; // Tốc độ xoáy ốc
    [SerializeField]
    public float deactivateDistance = 8f; // Khoảng cách khi vật thể sẽ tự động tắt
    [SerializeField]
    int shurikenNum; // Khoảng cách khi vật thể sẽ tự đ
    private float angle = 0f;

    [SerializeField]
    Transform ShurikenParent;

    private void OnEnable()
    {
        angle = 0f;
        radius = 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponentInParent<ShurikenScript>().ApllyDmg(collision);
    }

    private void Update()
    {
        if(Time.deltaTime != 0f)
        {
            if(shurikenNum == 0)
            {
                radius += 0.006f;
                // Tính toán vị trí mới của vật thể dựa trên góc và bán kính xoáy ốc
                float x = ShurikenParent.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
                float y = ShurikenParent.position.y + Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
                transform.position = new Vector3(x, y, 0);

                // Tăng góc để di chuyển vật thể
                angle += speed * Time.deltaTime;

                // Nếu khoảng cách vượt quá giá trị deactivateDistance, deactivate vật thể
                if (radius >= deactivateDistance)
                {
                    gameObject.SetActive(false);
                }
            }
            if (shurikenNum == 1)
            {
                radius += 0.01f;
                // Tính toán vị trí mới của vật thể dựa trên góc và bán kính xoáy ốc
                float x = ShurikenParent.position.x - Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
                float y = ShurikenParent.position.y - Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
                transform.position = new Vector3(x, y, 0);

                // Tăng góc để di chuyển vật thể
                angle += speed * Time.deltaTime;

                // Nếu khoảng cách vượt quá giá trị deactivateDistance, deactivate vật thể
                if (radius >= deactivateDistance)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
