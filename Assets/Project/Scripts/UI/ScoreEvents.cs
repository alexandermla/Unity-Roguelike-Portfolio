using System;

public static class ScoreEvents
{
    public static event Action<int> OnScoreAdded;

    public static void AddScore(int amount)
    {
        OnScoreAdded?.Invoke(amount);
    }
}

// ScriptRole: Broadcasts score changes
// RelatedScripts: ScoreManager, EnemyScoreReward
// SendsTo: ScoreManager