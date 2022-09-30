using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private PlatformSpawner _spawner;
    [SerializeField] private float _timeSpeed;
    [SerializeField] private bool _platformStopper = false;
    [SerializeField] private GameObject _frontPlatform;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private bool _gameState = false;
    public Action<float> TimeSpeed;
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
            if (!_platformStopper)
            {
                _timeSpeed += Time.deltaTime * 0.1f;
                this.gameObject.transform.position -= new Vector3(0f, 0f, (_speed + _timeSpeed) * Time.deltaTime);
                TimeSpeed?.Invoke(_timeSpeed);

            }
            else if (_platformStopper)
            {
                _timeSpeed += Time.deltaTime * 0.1f;
                this.gameObject.transform.position -= new Vector3(0f, 0f, (_speed + _timeSpeed) * Time.deltaTime);
                gameObject.transform.position = new Vector3(0f, 0f, Mathf.Clamp(gameObject.transform.position.z, -80f, 240f));
            }
        }
    }
    public GameObject GetFrontPlatform()
    {
        return _frontPlatform;
    }


}
