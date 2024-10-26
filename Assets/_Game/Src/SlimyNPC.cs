using UnityEngine;

public class SlimyNPC : MonoBehaviour
{
    [SerializeField] float waitBeforeHappy = 2f;
    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        Invoke(nameof(BeHappy), waitBeforeHappy);
    }

    void BeHappy()
    {
        animator.SetBool("IsHappy", true);
    }
}
