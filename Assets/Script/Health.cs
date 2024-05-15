using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int healthPercent;

    [SerializeField]
    float timeAutoDestroy=10f;

    float timer;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        timer = timeAutoDestroy;
    }

    private void Update()
    {
        timer-= Time.deltaTime;
        if(timer < 0)
        {
            animator.SetBool("isBroken", true);
            Destroy(gameObject, 0.3f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterInfo_1 heartPlayer = collision.GetComponent<CharacterInfo_1>();
        if (heartPlayer != null)
        {
            heartPlayer.HealthByPercent(healthPercent);
            animator.SetBool("isBroken", true);
            Destroy(gameObject, 0.3f);
        }
    }

}
