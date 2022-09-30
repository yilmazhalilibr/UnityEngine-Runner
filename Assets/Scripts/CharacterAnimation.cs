using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Zenject;
using System;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private bool _gameState = false;
    [SerializeField] private PlatformMovement _platformMovement;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _timeSpeed;
    [SerializeField] private JumpButton _jumpButton;
    [SerializeField] private GameObject _character;
    [SerializeField] private float _jumpForce = 250f;
    private GameManager _gameManager;
    private Action<bool> OnGameStateChangedAction;
    private Rigidbody _rigidbody;
    [Inject]
    private void Constructor(GameManager gameManager)
    {
        _gameManager = gameManager;
        _gameManager.GameState += OnGameStateChanged;
        _jumpButton.CharacterJumpButton += CharacterJump;
        _platformMovement.TimeSpeed += AnimationSpeed;
        OnGameStateChangedAction += AnimationSpeed;
        gameObject.TryGetComponent(out _animator);
        _character.TryGetComponent(out _rigidbody);
    }

    private void OnDestroy()
    {
        _gameManager.GameState -= OnGameStateChanged;
        _jumpButton.CharacterJumpButton -= CharacterJump;
        _platformMovement.TimeSpeed -= AnimationSpeed;
        OnGameStateChangedAction -= AnimationSpeed;

    }
    private void OnGameStateChanged(GameStates state)
    {
        if (state == GameStates.START)
        {
            _gameState = true;
        }
        else
        {
            _gameState = false;
            OnGameStateChangedAction?.Invoke(_gameState);
        }
    }
    private void AnimationSpeed(float speed)
    {
        if (_gameState)
        {
            _animator.SetBool("GameState", true);
            _animator.speed = (speed / 50) + 0.8f;
        }
        else
        {
            _animator.SetBool("GameState", false);
        }
    }
    private void AnimationSpeed(bool state)
    {
        _animator.SetBool("GameState", state);
        _animator.speed = 1;
    }
    private void CharacterJump()
    {
        StartCoroutine(JumpAnimation());
    }
    IEnumerator JumpAnimation()
    {
        _jumpButton.gameObject.SetActive(false);
        _animator.SetBool("Jump", true);
        _rigidbody.AddForce(transform.up * _jumpForce);
        yield return new WaitForSeconds(1f);

        //  UniTask.Delay(1500);
        _animator.SetBool("Jump", false);
        _jumpButton.gameObject.SetActive(true);
    }



}

