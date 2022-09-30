using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlatformSpawner : MonoBehaviour
{


    [SerializeField] private GameObject _platform;
    [SerializeField] private List<GameObject> _platformList;
    [SerializeField] private List<GameObject> _activePlatformList;
    [SerializeField] private float _obstacleSpace;
    private GameManager _gameManager;
    private bool _gameState = false;
    public Action<GameObject> OnSpawnState;
    private BoxCollider _boxCollider;
    [Inject]
    private void Constructor(GameManager gameManager)
    {
        _gameManager = gameManager;
        _gameManager.GameState += OnGameStateChanged;
    }
    private void OnDestroy()
    {
        _gameManager.GameState -= OnGameStateChanged;

    }
    private void Update()
    {
        if (_gameState)
        {
            PlatformSpawn();
        }
    }
    private void OnGameStateChanged(GameStates gameStates)
    {
        if (gameStates == GameStates.START)
        {
            _gameState = true;
        }
        else
        {
            _gameState = false;
        }
    }
    private void PlatformSpawn()
    {

        foreach (var item in _activePlatformList)
        {
            if (item.transform.position.z <= -79.98f)
            {
                item.TryGetComponent(out PlatformMovement _platformMovement);
                _platformMovement.gameObject.TryGetComponent(out _boxCollider);
                _boxCollider.isTrigger = true;
                var frontPlatform = _platformMovement.GetFrontPlatform();
                item.transform.position = new Vector3(0f, 0f, frontPlatform.transform.position.z + _obstacleSpace);
                OnSpawnState?.Invoke(item);
                _boxCollider.isTrigger = false;


            }
        }

    }





}
