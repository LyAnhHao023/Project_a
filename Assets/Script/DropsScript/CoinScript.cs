using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    int coins = 2;

    GameObject player;

    bool isNotFollow = false;

    AudioManager audioManager;

    public void SetPlayer(GameObject gameObject)
    {
        player = gameObject;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void IncreaseCoin(int number)
    {
        coins = number;
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
            audioManager.PlaySFX(audioManager.PickUpCoin);
            Destroy(gameObject);
            c.GainCoin(coins);
        }
    }
}
