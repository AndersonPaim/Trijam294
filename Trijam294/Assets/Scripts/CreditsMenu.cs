using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsMenu : MonoBehaviour
{
    [SerializeField] private Button _backButton;

    private void Start()
    {
        _backButton.onClick.AddListener(StartGame);
    }

    private void OnDestroy()
    {
        _backButton.onClick.RemoveAllListeners();
    }

    private void StartGame()
    {
        gameObject.SetActive(false);
    }
}
