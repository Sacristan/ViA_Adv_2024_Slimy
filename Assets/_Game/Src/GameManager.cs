using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public event System.Action OnGameWon;
    public event System.Action OnAllMushroomsCollected;
    public event System.Action OnSlimyHasBeenFed;
    public event System.Action<Mushroom> OnMushroomCollected;

    List<Mushroom> _mushrooms;
    bool hasGameBeenWon = false;

    [SerializeField] float victoryDelayTime = 1.5f;
    [SerializeField] float gameWonTimeRestartLevel = 3f;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Collected(Mushroom mushroom)
    {
        Debug.Log("Collected: " + mushroom.gameObject.name);
        OnMushroomCollected?.Invoke(mushroom);
        _mushrooms.Remove(mushroom);

        if (_mushrooms.Count <= 0)
        {
            OnAllMushroomsCollected?.Invoke();
            // GameWon();
        }
    }

    public void SlimyHasBeenFed()
    {
        OnSlimyHasBeenFed?.Invoke();

        Invoke(nameof(GameWon), victoryDelayTime);
    }

    void GameWon()
    {
        if (!hasGameBeenWon)
        {
            hasGameBeenWon = true;

            Debug.Log("Game won!");
            OnGameWon?.Invoke();

            Invoke(nameof(RestartGame), gameWonTimeRestartLevel);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}