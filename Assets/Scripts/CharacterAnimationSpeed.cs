using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Zenject;

public class CharacterAnimationSpeed : MonoBehaviour
{
    [SerializeField] private bool _gameState = false;
    [SerializeField] private PlatformMovement _platformMovement;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _timeSpeed;
    [SerializeField] private JumpButton _jumpButton;
    [SerializeField] private GameObject _character;
    private GameManager _gameManager;
    [Inject]
    private void Constructor(GameManager gameManager)
    {
        _gameManager = gameManager;
        _gameManager.GameState += OnGameStateChanged;
        _jumpButton.CharacterJumpButton += CharacterJump;
        _platformMovement.TimeSpeed += AnimationSpeed;
        gameObject.TryGetComponent(out _animator);
    }
  
    private void OnDestroy()
    {
        _gameManager.GameState -= OnGameStateChanged;
        _jumpButton.CharacterJumpButton -= CharacterJump;
        _platformMovement.TimeSpeed -= AnimationSpeed;
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
    private void CharacterJump()
    {
        StartCoroutine(JumpAnimation());
    }
    IEnumerator JumpAnimation()
    {
        _jumpButton.gameObject.SetActive(false);
        _animator.SetBool("Jump", true);
        TryGetComponent(out Rigidbody rb);
        rb.AddForce(transform.up * 250f);
        yield return new WaitForSeconds(1f);
        //  UniTask.Delay(1500);
        _animator.SetBool("Jump", false);
        _jumpButton.gameObject.SetActive(true);

    }
}

