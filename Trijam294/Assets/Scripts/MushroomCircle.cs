using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MushroomCircle : MonoBehaviour
{
    [SerializeField] private Transform _teleportPosition;
    [SerializeField] private Image _fadeBG;
    [SerializeField] private List<ParticleSystem> _particles = new List<ParticleSystem>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player)
        {
            foreach (ParticleSystem particle in _particles)
            {
                particle.Play();
            }

            player.StopMovement();
            Sequence sequence = DOTween.Sequence().SetUpdate(true);
            sequence.AppendInterval(1.5f);
            sequence.Append(_fadeBG.DOFade(1, 1f));
            sequence.AppendCallback(() => player.gameObject.transform.position = _teleportPosition.position);
            sequence.Append(_fadeBG.DOFade(0, 1f));
            sequence.AppendCallback(() => player.StartMovement());
        }
    }
}
