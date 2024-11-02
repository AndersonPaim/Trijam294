using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CampFire : MonoBehaviour
{
    [SerializeField] private Light2D _light;
    [SerializeField] private bool _startActivated;
    [SerializeField] private int _lightIntensity;

    public bool IsActivated => _isActivated;

    private bool _isActivated;

    public void ActivateCampFire()
    {
        _isActivated = true;
        DOTween.To(() => _light.intensity, x => _light.intensity = x, _lightIntensity, 2);
    }

    private void Start()
    {
        if (_startActivated)
        {
            ActivateCampFire();
        }
    }
}
