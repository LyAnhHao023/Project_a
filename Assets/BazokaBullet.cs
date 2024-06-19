using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazokaBullet : MonoBehaviour
{
    [SerializeField]
    float timeAutoDestroy = 10f;
    [SerializeField] GameObject ExplodePrefab;
    public void SetDmg(int dmg, bool isCrit)
    {
        ExplodePrefab.GetComponent<BazokaBulletExplode>().SetDmg(dmg, isCrit);
    }

    private void Start()
    {
        Destroy(gameObject, timeAutoDestroy);    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            GetComponent<Renderer>().enabled = false;
            ExplodePrefab.SetActive(true);
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.zero;
            Destroy(gameObject, 0.4f);
        }

    }
}
