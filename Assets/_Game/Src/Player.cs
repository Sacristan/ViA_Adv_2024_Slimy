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
    }

    private void OnMushroomsCollected()
    {
        mushroomRepresentation.SetActive(true);
    }
}
