using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    public Action OnTorchTurnOff;
    public Action OnFindExit;
    public Action OnDeath;

    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Light2D _torchLight;
    [SerializeField] private AudioSource _turnOnfireSFX;
    [SerializeField] private AudioSource _turnOfffireSFX;
    [SerializeField] private AudioSource _fireSFX;
    [SerializeField] private string _exitTag;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _torchLightIntensity;
    [SerializeField] private float _torchDuration;

    public bool HasTorch => _hasTorch;

    private bool _hasTorch = true;
    private bool _isRecharging = false;
    private bool _canMove = true;
    private float _currentTorchDuration;
    private Tween _torchTween;

    public void StopMovement()
    {
        _canMove = false;
    }

    private void Start()
    {
        _fireSFX.Play();
        _turnOnfireSFX.Play();
        _currentTorchDuration = _torchDuration;
        _torchTween = DOTween.To(() => _torchLight.intensity, x => _torchLight.intensity = x, 0, _torchDuration).OnComplete(TorchTurnOff); ;
    }

    private void Update()
    {
        if (!_isRecharging)
        {
            _currentTorchDuration -= Time.deltaTime;
        }

        Movement();
    }

    private void Movement()
    {
        _rb.velocity = new Vector2(0, 0);

        if (!_canMove)
        {
            return;
        }

        Vector2 newVelocity = _rb.velocity;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newVelocity.x = -_moveSpeed;
            _animator.SetInteger("DirectionX", -1);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newVelocity.x = _moveSpeed;
            _animator.SetInteger("DirectionX", 1);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newVelocity.y = _moveSpeed;
            _animator.SetInteger("DirectionY", 1);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newVelocity.y = -_moveSpeed;
            _animator.SetInteger("DirectionY", -1);
        }

        //KEY UP

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _animator.SetInteger("DirectionX", 0);
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _animator.SetInteger("DirectionX", 0);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            _animator.SetInteger("DirectionY", 0);
        }
        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            _animator.SetInteger("DirectionY", 0);
        }

        _rb.velocity = newVelocity;
    }

    private void RechargeTorch()
    {
        _turnOnfireSFX.Play();
        _isRecharging = true;
        _currentTorchDuration = _torchDuration;
        _torchTween.Kill();

        DOTween.To(() => _torchLight.intensity, x => _torchLight.intensity = x, _torchLightIntensity, 1);
    }

    private void RechargeCompleted()
    {
        _isRecharging = false;
        _torchTween = DOTween.To(() => _torchLight.intensity, x => _torchLight.intensity = x, 0, _currentTorchDuration).OnComplete(TorchTurnOff);
    }

    private void TorchTurnOff()
    {
        _fireSFX.Stop();
        _turnOfffireSFX.Play();
        OnTorchTurnOff?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CampFire campfire = other.GetComponent<CampFire>();
        Trap trap = other.GetComponent<Trap>();

        if (trap)
        {
            trap.EnterTrap();
            OnDeath?.Invoke();
        }

        if (campfire)
        {
            if (campfire.IsActivated || _currentTorchDuration > 0)
            {
                RechargeTorch();
            }

            if (_currentTorchDuration > 0)
            {
                campfire.ActivateCampFire();
            }
        }

        if (other.gameObject.CompareTag(_exitTag))
        {
            OnFindExit?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_isRecharging)
        {
            RechargeCompleted();
        }
    }
}
