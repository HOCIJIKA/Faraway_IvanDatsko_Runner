using UnityEngine;

/// <summary>
/// Restart player if Triggered
/// </summary>
public class DiePlace : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StaticActions.RestartPlayer?.Invoke();
        }
    }
}
