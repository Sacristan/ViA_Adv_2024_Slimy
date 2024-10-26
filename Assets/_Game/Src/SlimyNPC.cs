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
        // Debug.Log("Slimy personal space intruder: " + other.gameObject.name);
        SetHappy(true);
    }

    void OnTriggerExit(Collider other)
    {
        SetHappy(false);
    }

    void SetHappy(bool flag)
    {
        animator.SetBool("IsHappy", flag);
    }
}
