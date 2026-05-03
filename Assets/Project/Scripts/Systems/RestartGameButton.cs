using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameButton : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1f;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);

        Debug.Log("Game restarted");
    }
}

// ScriptRole: Restarts current scene
// RelatedScripts: GameOverPanelUI
// UsesSO: None