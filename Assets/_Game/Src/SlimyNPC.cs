using System;
using UnityEngine;

public class SlimyNPC : MonoBehaviour
{
    Animator animator;
    bool hasAllMushroomsBeenCollected = false;

    [SerializeField] AudioSource squakyFX;

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();

        GameManager.instance.OnAllMushroomsCollected += OnAllMushroomsCollected;
    }

    public void OnPlayerEnteredHappyZone()
    {
        if (hasAllMushroomsBeenCollected)
        {
            SetHappy(true);
        }
    }

    public void OnPlayerLeftHappyZone()
    {
        SetHappy(false);
    }

    void SetHappy(bool flag)
    {
        animator.SetBool("IsHappy", flag);

        if (flag)
        {
            squakyFX.Play();
        }
        else
        {
            squakyFX.Stop();
        }
    }

    private void OnAllMushroomsCollected()
    {
        hasAllMushroomsBeenCollected = true;
    }
}
