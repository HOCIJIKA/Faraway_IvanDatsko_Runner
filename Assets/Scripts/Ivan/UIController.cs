using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _jump;
    [SerializeField] private Button _restart;

    private void Awake()
    {
        _jump.onClick.AddListener(PlayerJump);
        _restart.onClick.AddListener(Restart);
    }

    private void PlayerJump()
    {
        _player.IsJump = true;
    }
    
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        _jump.onClick.RemoveListener(PlayerJump);
        _jump.onClick.RemoveListener(Restart);
    }
}
