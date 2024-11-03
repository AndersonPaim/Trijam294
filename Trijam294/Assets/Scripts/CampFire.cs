using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CampFire : MonoBehaviour
{
    [SerializeField] private Light2D _light;
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _startActivated;
    [SerializeField] private int _lightIntensity;
    [SerializeField] private int _fireDuration;

    public bool IsActivated => _isActivated;

    private Tween _torchTween;
    private bool _isActivated;
    private float _currentFireDuration;

    public void ActivateCampFire()
    {
        _torchTween.Kill();
        _animator.SetTrigger("Play");
        _currentFireDuration = _fireDuration;
        _isActivated = true;

        DOTween.To(() => _light.intensity, x => _light.intensity = x, _lightIntensity, 4).OnComplete
        (
            () => _torchTween = DOTween.To(() => _light.intensity, x => _light.intensity = x, 0, _currentFireDuration).OnComplete(DeactivateCampFire)
        );
    }

    private void DeactivateCampFire()
    {
        _isActivated = false;
        _animator.SetTrigger("Stop");
    }

    private void Start()
    {
        if (_startActivated)
        {
            ActivateCampFire();
        }
    }

    private void Update()
    {
        if (_isActivated)
        {
            _currentFireDuration -= Time.deltaTime;
        }
    }
}
