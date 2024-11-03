using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _quitButton;

    private void OnEnable()
    {
        StartAnimation();
    }

    private void StartAnimation()
    {
        Sequence sequence = DOTween.Sequence().SetUpdate(true);
        sequence.Append(_background.DOFade(0.9f, 1).SetUpdate(true));
        sequence.Append(_gameOverText.DOFade(1, 1).SetUpdate(true));
        sequence.Append(_restartButton.transform.DOScale(Vector3.one, 0.4f).SetUpdate(true));
        sequence.Append(_quitButton.transform.DOScale(Vector3.one, 0.4f).SetUpdate(true));
    }

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