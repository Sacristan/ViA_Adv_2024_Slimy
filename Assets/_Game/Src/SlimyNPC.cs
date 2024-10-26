using UnityEngine;

public class SlimyNPC : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SetHappy(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SetHappy(false);
        }
    }

    void SetHappy(bool flag)
    {
        animator.SetBool("IsHappy", flag);
    }
}
