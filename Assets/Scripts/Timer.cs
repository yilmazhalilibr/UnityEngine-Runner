using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private bool _gameState;
    private float _time;
    private void Awake()
    {
        _gameManager.GameState += GameStateChanged;
    }
    private void OnDestroy()
    {
        _gameManager.GameState -= GameStateChanged;
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
    private void FixedUpdate()
    {
        if (_gameState)
        {
            _time += Time.deltaTime * 1;
            _timeText.text = $"TIME : {(int)_time}";
        }
    }
}
