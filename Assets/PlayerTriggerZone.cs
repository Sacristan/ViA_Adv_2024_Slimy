using UnityEngine;
using UnityEngine.Events;

public class PlayerTriggerZone : MonoBehaviour
{
    [SerializeField] UnityEvent OnPlayerEnteredZone;
    [SerializeField] UnityEvent OnPlayerLeftZone;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerEnteredZone?.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerLeftZone?.Invoke();
        }
    }

}
