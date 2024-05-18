using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private int moveSpeed;

    private Animator animation;

    //Ẩn đi phần chỉnh sửa trên Inspector
    [HideInInspector]
    public Vector3 moveInput;

    [HideInInspector]
    public float scaleX;

    GameObject Character;

    CharacterStats characterStats;

    private void Start()
    {
        Character = GameObject.Find("FistCharDev");
        animation = Character.GetComponent<Animator>();
        characterStats = GetComponent<CharacterInfo_1>().characterStats;
    }

    private void Update()
    {
        moveInput.x=Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * characterStats.speed * Time.deltaTime;

        animation.SetFloat("Speed", moveInput.sqrMagnitude);

        if (moveInput.x != 0)
        {

            if(moveInput.x > 0)
            {
                animation.transform.rotation = Quaternion.Euler(0, 0, 0);
                scaleX = 1;
            }
            else
            {
                animation.transform.rotation = Quaternion.Euler(0, 180, 0);
                scaleX = -1;
            }
        }
    }
}
