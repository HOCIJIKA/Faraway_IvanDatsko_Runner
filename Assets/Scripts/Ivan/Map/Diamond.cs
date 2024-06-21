using UnityEngine;

/// <summary>
/// Decorate map object Diamond
/// </summary>
public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
