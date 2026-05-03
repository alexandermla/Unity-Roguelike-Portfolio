using UnityEngine;

public class GameOverPanelUI : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject panel;

    private void Awake()
    {
        panel.SetActive(false);
    }

    public void ShowPanel()
    {
        panel.SetActive(true);
        Debug.Log("Game Over panel shown");
    }
}

// ScriptRole: Shows game over panel
// RelatedScripts: GameOverManager
// UsesSO: None
// ReceivesFrom: GameOverManager