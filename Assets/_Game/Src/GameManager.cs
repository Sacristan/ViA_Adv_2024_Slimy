using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public event System.Action OnGameWon;
    public event System.Action<Mushroom> OnMushroomCollected;

    List<Mushroom> _mushrooms;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        _mushrooms = new(
            FindObjectsByType<Mushroom>(FindObjectsSortMode.None)
        );
    }

    public void Collected(Mushroom mushroom)
    {
        Debug.Log("Collected: " + mushroom.gameObject.name);
        OnMushroomCollected?.Invoke(mushroom);
        _mushrooms.Remove(mushroom);

        if (_mushrooms.Count <= 0)
        {
            GameWon();
        }
    }

    void GameWon()
    {
        Debug.Log("Game won!");
        OnGameWon?.Invoke();
    }

}