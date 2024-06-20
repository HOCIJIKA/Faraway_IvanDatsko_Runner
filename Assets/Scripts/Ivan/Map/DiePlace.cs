using UnityEngine;

public class DiePlace : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StaticActions.RestartMap?.Invoke();
        }
    }
}
