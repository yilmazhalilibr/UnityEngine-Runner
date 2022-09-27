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
    private void GameState(bool state)
    {
        if (state)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
