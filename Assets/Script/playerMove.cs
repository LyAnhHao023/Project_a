using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Animator animation;

    //Ẩn đi phần chỉnh sửa trên Inspector
    [HideInInspector]
    public Vector3 moveInput;

    [HideInInspector]
    public float scaleX;

    private void Start()
    {
        animation = GetComponent<Animator>();
    }

    private void Update()
    {
        moveInput.x=Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;

        animation.SetFloat("Speed", moveInput.sqrMagnitude);

        if (moveInput.x != 0)
        {

            if(moveInput.x > 0)
            {
               transform.localScale = new Vector3(1, 1, 1);
                scaleX = 1;
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
                scaleX = -1;
            }
        }
    }
}
