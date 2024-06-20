using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [FormerlySerializedAs("_player")] [SerializeField] private PlayerController playerController;
    [SerializeField] private Button _jump;
    [SerializeField] private Button _restart;

    private void Awake()
    {
        _jump.onClick.AddListener(PlayerJump);
        _restart.onClick.AddListener(Restart);
    }

    private void PlayerJump()
    {
        playerController.PlayerMovement.IsJump = true;
    }
    
    private void Restart()
    {
        StaticActions.RestartMap?.Invoke();
    }

    private void OnDestroy()
    {
        _jump.onClick.RemoveListener(PlayerJump);
        _jump.onClick.RemoveListener(Restart);
    }
}
