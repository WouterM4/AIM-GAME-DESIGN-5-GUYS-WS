using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class FinishTrigger : MonoBehaviour
{
    [Tooltip("Assign the GameState asset.")]
    public GameState gameState;

    [Tooltip("UI Text or TMP Text object to display 'Victory' (optional).")]
    public GameObject victoryUI; // set active on victory

    [Tooltip("Optional UnityEvent for additional actions on victory.")]
    public UnityEvent onVictory;

    private void Reset()
    {
        var col = GetComponent<Collider>();
        col.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // assume player has tag "Player"
        if (other.CompareTag("Player") && gameState != null)
        {
            gameState.SetVictory();
            if (victoryUI != null) victoryUI.SetActive(true);
            onVictory?.Invoke();
        }
    }
}
