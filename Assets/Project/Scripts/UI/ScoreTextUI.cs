using TMPro;
using UnityEngine;

public class ScoreTextUI : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TMP_Text scoreText;

    [Header("Format")]
    [SerializeField] private string prefixText = "Score: ";

    public void UpdateScoreText(int score)
    {
        scoreText.text = prefixText + score;
        Debug.Log("Score UI updated");
    }
}

// ScriptRole: Updates score text using TextMeshPro
// RelatedScripts: ScoreManager
// UsesSO: None
// ReceivesFrom: ScoreManager