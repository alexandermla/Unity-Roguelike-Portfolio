using UnityEngine;

public class EnemyScoreReward : MonoBehaviour
{
    [Header("Reward")]
    [SerializeField] private int scoreAmount = 10;

    public void GiveScore()
    {
        Debug.Log(gameObject.name + " gave score: " + scoreAmount);
        ScoreEvents.AddScore(scoreAmount);
    }
}

// ScriptRole: Gives score when enemy dies
// RelatedScripts: Health, ScoreEvents, ScoreManager
// UsesSO: None
// ReceivesFrom: Health
// SendsTo: ScoreEvents