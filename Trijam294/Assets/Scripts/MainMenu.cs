using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private GameObject _creditsMenu;

    private void Start()
    {
        _playButton.onClick.AddListener(StartGame);
        _quitButton.onClick.AddListener(QuitGame);
        _creditsButton.onClick.AddListener(Credits);
    }

    private void OnDestroy()
    {
        _playButton.onClick.RemoveAllListeners();
        _quitButton.onClick.RemoveAllListeners();
        _creditsButton.onClick.RemoveAllListeners();
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void Credits()
    {
        _creditsMenu.SetActive(true);
    }
}
