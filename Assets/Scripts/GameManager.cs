using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    public bool _gameStarting = false;
    public Action<GameStates> GameState;


    [Inject]
    private void Constructor()
    {
        _startButton.onClick.AddListener(GameStart);

    }
    private void OnDestroy()
    {
        _startButton.onClick.RemoveListener(GameStart);
    }

    public void GameStart()
    {
        _gameStarting = true;
        GameState?.Invoke(GameStates.START);
    }
    public void GameFailed()
    {
        _gameStarting = false;
        GameState?.Invoke(GameStates.END);
        Debug.Log(_gameStarting);
    }
    public bool GetGameStateBool()
    {
        return _gameStarting;
    }
    public GameStates GetGameStateEnum()
    {
        if (_gameStarting)
        {
            return GameStates.START;
        }
        return GameStates.END;
    }


}
