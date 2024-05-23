using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleExp : MonoBehaviour
{
    [SerializeField]
    int expBuff = 2;

    GameObject player;

    bool isNotFollow = false;

    public void SetPlayer(GameObject gameObject)
    {
        player = gameObject;
    }

    public void IncreaseExpBuff(int number)
    {
        expBuff = number;
    }
    private void FixedUpdate()
    {
        if (!isNotFollow)
        {
            isNotFollow = Physics2D.OverlapCircle(transform.position, 5f, LayerMask.GetMask("Player"));
        }
        else
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * 10 * Time.deltaTime;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterInfo_1 c = collision.GetComponent<CharacterInfo_1>();
        if (c != null)
        {
            Destroy(gameObject);
            c.GainExp(expBuff);
        }
    }
}