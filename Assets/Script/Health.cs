using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int healthPercent;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthTest heartPlayer = collision.GetComponent<HealthTest>();
        if (heartPlayer != null)
        {
            heartPlayer.HealthByPercent(healthPercent);
            animator.SetBool("isBroken", true);
            Invoke("DestroyHeart", 0.3f);
        }
    }

    public void DestroyHeart()
    {
        Destroy(gameObject);
    }

}
