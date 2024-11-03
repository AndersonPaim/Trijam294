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

    public bool IsActivated => _isActivated;

    private bool _isActivated;

    public void ActivateCampFire()
    {
        _animator.SetTrigger("Play");
        _isActivated = true;
        DOTween.To(() => _light.intensity, x => _light.intensity = x, _lightIntensity, 4);
    }

    private void Start()
    {
        if (_startActivated)
        {
            ActivateCampFire();
        }
    }
}
