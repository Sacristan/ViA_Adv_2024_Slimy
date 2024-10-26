using UnityEngine;

public class SlimyNPC : MonoBehaviour
{
    Animator animator;
    AudioSource _audioSource;

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        _audioSource = GetComponent<AudioSource>();
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

        if (flag)
        {
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }
    }
}
