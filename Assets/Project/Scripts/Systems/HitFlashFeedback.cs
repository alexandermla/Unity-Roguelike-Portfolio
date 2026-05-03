using System.Collections;
using UnityEngine;

public class HitFlashFeedback : MonoBehaviour
{
    [Header("Visual")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Flash")]
    [SerializeField] private Color flashColor = Color.white;
    [SerializeField] private float flashDuration = 0.08f;

    private Color originalColor;
    private Coroutine flashRoutine;

    private void Awake()
    {
        originalColor = spriteRenderer.color;
    }

    public void PlayFlash()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }

        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        Debug.Log(gameObject.name + " hit flash started");

        spriteRenderer.color = flashColor;

        yield return new WaitForSeconds(flashDuration);

        spriteRenderer.color = originalColor;

        Debug.Log(gameObject.name + " hit flash ended");
    }
}

// ScriptRole: Plays a short hit flash on damage
// RelatedScripts: Health
// UsesSO: None
// ReceivesFrom: Health