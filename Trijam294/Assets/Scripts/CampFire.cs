using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    [SerializeField] private bool _startActivated;

    public void ActivateCampFire()
    {

    }

    private void Start()
    {
        if (_startActivated)
        {
            ActivateCampFire();
        }
    }
}
