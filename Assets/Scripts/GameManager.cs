using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private bool _gameState = false;
    public Action<bool> GameState;

    private void Awake()
    {
        _startButton.onClick.AddListener(GameStart);
    }
    private void OnDestroy()
    {
        _startButton.onClick.RemoveListener(GameStart);
    }
    private void GameStart()
    {
        _gameState = true;
        GameState?.Invoke(_gameState);
    }
    private void GameFailed()
    {
        _gameState = false;
        GameState?.Invoke(_gameState);

    }


}
