using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerTriggerEnter : MonoBehaviour
{
    private GameManager _gameManager;
    private const string OBSTACLE = "Obstacle";
    [Inject]
    private void Constructor(GameManager gameManager)
    {
        _gameManager = gameManager;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(OBSTACLE))
        {
            _gameManager.GameFailed();
        }
    }
}
