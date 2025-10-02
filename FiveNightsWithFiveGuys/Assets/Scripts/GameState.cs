using UnityEngine;
using System;

[CreateAssetMenu(fileName = "GameState", menuName = "Scriptable Objects/GameState")]
public class GameState : ScriptableObject
{
    public bool IsVictory => isVictory;
    [SerializeField] private bool isVictory = false;

    // Event so listeners can stop when victory happens
    public event Action OnVictory;

    // Call this to set victory once
    public void SetVictory()
    {
        if (isVictory) return;
        isVictory = true;
        OnVictory?.Invoke();
    }

    // For editor/testing: reset
    public void Reset()
    {
        isVictory = false;
    }
}