using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    [SerializeField] private Button _jump;

    private void Awake()
    {
        _jump.onClick.AddListener(PlayerJump);
    }

    private void PlayerJump()
    {
        _player.IsJump = true;
    }
}
