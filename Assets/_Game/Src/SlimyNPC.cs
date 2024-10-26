using System;
using UnityEngine;

public class SlimyNPC : MonoBehaviour
{
    Animator animator;
    bool hasAllMushroomsBeenCollected = false;

    [SerializeField] AudioSource squakyFX;
    [SerializeField] AudioSource nomnomFX;


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

    public void OnPlayerEnterFeedingZone()
    {
        if (hasAllMushroomsBeenCollected)
        {
            nomnomFX.Play();
            GameManager.instance.SlimyHasBeenFed();
        }
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
