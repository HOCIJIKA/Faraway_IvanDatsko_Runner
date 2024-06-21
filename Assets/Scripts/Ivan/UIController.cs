using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    public void OnPlayerJump()
    {
        playerController.PlayerMovement.IsJump = true;
    }
    
    public void OnRestart()
    {
        StaticActions.RestartPlayer?.Invoke();
    }
}
