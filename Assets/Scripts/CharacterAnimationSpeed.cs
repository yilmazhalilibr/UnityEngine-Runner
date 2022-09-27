using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationSpeed : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private bool _gameState = false;
    [SerializeField] private PlatformMovement _platformMovement;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _timeSpeed;
    [SerializeField] private JumpButton _jumpButton;
    [SerializeField] private GameObject _character;
    private void Awake()
    {
        _jumpButton.CharacterJumpButton += CharacterJump;
        _gameManager.GameState += GameStateChanged;
        _platformMovement.TimeSpeed += AnimationSpeed;
    }
    private void Start()
    {
        gameObject.TryGetComponent(out _animator);
    }
    private void OnDestroy()
    {
        _jumpButton.CharacterJumpButton -= CharacterJump;
        _gameManager.GameState -= GameStateChanged;
        _platformMovement.TimeSpeed -= AnimationSpeed;
    }

    private void GameStateChanged(bool state)
    {
        _gameState = state;
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
        yield return new WaitForSeconds(1.25f);
        _animator.SetBool("Jump", false);
        _jumpButton.gameObject.SetActive(true);

    }
}

