using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _trapAudio;

    public void EnterTrap()
    {
        _animator.SetTrigger("Play");
        _trapAudio.Play();
    }
}
