using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;
    [SerializeField] private PlatformMovement _platformMovement;
    [SerializeField] private Joystick _joystick;
    private float _horizontal;
    private GameManager _gameManager;

    [Inject]
    private void Constructor(GameManager gameManager)
    {
        _gameManager = gameManager;
        _platformMovement.TimeSpeed += TimeStateSpeedChanger;

    }

    private void OnDestroy()
    {
        _platformMovement.TimeSpeed -= TimeStateSpeedChanger;

    }
    private void Update()
    {
        _horizontal = _joystick.Horizontal;
        _player.transform.Translate(_horizontal * Time.deltaTime * _speed, 0f, 0f);
        _player.transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3, 3), _player.transform.position.y, _player.transform.position.z);
    }
    private void TimeStateSpeedChanger(float time)
    {
        _speed = (time + 6) / 2f;
    }
  
}
