using UnityEngine;

public class DestroyOnDeath : MonoBehaviour
{
    public void DestroyObject()
    {
        Debug.Log(gameObject.name + " destroyed");
        Destroy(gameObject);
    }
}

// ScriptRole: Destroys object when death event is received
// RelatedScripts: Health
// UsesSO: None
// ReceivesFrom: Health