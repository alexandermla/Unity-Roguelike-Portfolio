using UnityEngine;
using UnityEngine.Events;

public class GameOverManager : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent OnGameOver;

    private bool isGameOver;

    public void TriggerGameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0f;

        Debug.Log("Game Over triggered");
        OnGameOver?.Invoke();
    }
}

// ScriptRole: Handles game over state
// RelatedScripts: Health, GameOverPanelUI
// UsesSO: None
// ReceivesFrom: Health
// SendsTo: GameOverPanelUI