using TMPro;
using UnityEngine;

public class VictoryUIDisplayer : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private TextMeshProUGUI victoryText;

    private void Awake()
    {
        if (victoryText != null) victoryText.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (gameState != null) gameState.OnVictory += ShowVictory;
    }

    private void OnDisable()
    {
        if (gameState != null) gameState.OnVictory -= ShowVictory;
    }

    private void ShowVictory()
    {
        if (victoryText != null) victoryText.gameObject.SetActive(true);
    }
}
