using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    public Action OnDisapear;
    [SerializeField] private float _maxPlayerDistance;

    private PlayerController _player;

    public void Initialize(float delay, PlayerController player)
    {
        _player = player;
        StartCoroutine(DisapearDelay(delay));
    }

    private IEnumerator DisapearDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Disapear();
    }

    private void Disapear()
    {
        OnDisapear?.Invoke();
        Destroy(gameObject);
    }

    private void Update()
    {
        if (!_player)
        {
            return;
        }

        if (Vector3.Distance(transform.position, _player.transform.position) < _maxPlayerDistance)
        {
            Disapear();
        }
    }
}
