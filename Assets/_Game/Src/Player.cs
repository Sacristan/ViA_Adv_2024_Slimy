using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject mushroomRepresentation;

    private void Start()
    {
        GameManager.instance.OnAllMushroomsCollected += OnMushroomsCollected;
        GameManager.instance.OnSlimyHasBeenFed += OnSlimyHasBeenFed;
    }

    private void OnMushroomsCollected()
    {
        mushroomRepresentation.SetActive(true);
    }

    private void OnSlimyHasBeenFed()
    {
        mushroomRepresentation.SetActive(false);
    }
}
