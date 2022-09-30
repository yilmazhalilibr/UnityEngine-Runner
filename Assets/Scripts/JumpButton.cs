using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour
{
    [SerializeField] private Button _jumpButton;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private bool _gameState = false;
    public event Action CharacterJumpButton;
    private void Awake()
    {
        _gameManager.GameState += GameStateChanged;
        _jumpButton.onClick.AddListener(JumpInvorker);
    }
    private void OnDestroy()
    {
        _gameManager.GameState -= GameStateChanged;
        _jumpButton.onClick.RemoveListener(JumpInvorker);
    }
    private void GameStateChanged(GameStates state)
    {
        if (state == GameStates.START)
        {
            _gameState = true;
        }
        else
        {
            _gameState = false;
        }
    }
    private void JumpInvorker()
    {
        if (_gameState)
        {
            CharacterJumpButton?.Invoke();
        }
    }

}
