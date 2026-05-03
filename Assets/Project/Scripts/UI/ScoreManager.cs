using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent<int> OnScoreChanged;

    private int currentScore;

    private void OnEnable()
    {
        ScoreEvents.OnScoreAdded += AddScore;
    }

    private void OnDisable()
    {
        ScoreEvents.OnScoreAdded -= AddScore;
    }

    private void Start()
    {
        OnScoreChanged?.Invoke(currentScore);
        Debug.Log("Score initialized");
    }

    private void AddScore(int amount)
    {
        if (amount <= 0) return;

        currentScore += amount;

        Debug.Log("Score added: " + amount);
        OnScoreChanged?.Invoke(currentScore);
    }
}

// ScriptRole: Stores and updates current score
// RelatedScripts: ScoreEvents, EnemyScoreReward, ScoreTextUI
// UsesSO: None
// ReceivesFrom: ScoreEvents
// SendsTo: ScoreTextUI