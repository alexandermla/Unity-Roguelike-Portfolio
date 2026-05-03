using TMPro;
using UnityEngine;

public class WaveTextUI : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TMP_Text waveText;

    [Header("Format")]
    [SerializeField] private string prefixText = "Wave: ";

    public void UpdateWaveText(int wave)
    {
        waveText.text = prefixText + wave;
        Debug.Log("Wave UI updated");
    }
}

// ScriptRole: Updates wave text using TextMeshPro
// RelatedScripts: WaveManager
// UsesSO: None
// ReceivesFrom: WaveManager