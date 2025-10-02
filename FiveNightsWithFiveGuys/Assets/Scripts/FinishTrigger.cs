using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private GameObject victoryUI;

    private void Start()
    {
        if (victoryUI != null) victoryUI.SetActive(false);
    }
    
    private void Reset()
    {
        var col = GetComponent<Collider>();
        col.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameState.IsVictory) return;
        if (!other == GameObject.Find("Player")) return;
        
        gameState.SetVictory();
        if (victoryUI != null) victoryUI.SetActive(true);
    }
}
