using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource victorySFX;
    [SerializeField] AudioSource collectedSFX;
    AudioSource _musicAudio;

    void Start()
    {
        _musicAudio = GetComponent<AudioSource>();
        GameManager.instance.OnGameWon += PlayVictorySFX;
        GameManager.instance.OnMushroomCollected += OnMushroomCollected;
    }

    void PlayVictorySFX()
    {
        collectedSFX.Stop();
        _musicAudio.Stop();
        victorySFX.Play();
    }

    private void OnMushroomCollected(Mushroom mushroom)
    {
        collectedSFX.transform.position = mushroom.transform.position;
        collectedSFX.Play();
    }

}
