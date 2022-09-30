using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private void Awake()
    {
        _gameManager.GameState += GameState;
    }
    private void OnDestroy()
    {
        _gameManager.GameState -= GameState;
    }
    private void GameState(GameStates state)
    {
        if (state == GameStates.START)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
