using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _quitButton;

    private void Start()
    {
        _restartButton.onClick.AddListener(RestartGame);
        _quitButton.onClick.AddListener(QuitGame);
    }

    private void OnDestroy()
    {
        _restartButton.onClick.RemoveAllListeners();
        _quitButton.onClick.RemoveAllListeners();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}