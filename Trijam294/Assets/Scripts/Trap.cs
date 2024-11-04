using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void EnterTrap()
    {
        _animator.SetTrigger("Play");
    }
}
