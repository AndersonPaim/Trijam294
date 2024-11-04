using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private GameObject _gameCompletedUI;

    private void Start()
    {
        Time.timeScale = 1;
        _playerController.OnTorchTurnOff += GameOver;
        _playerController.OnDeath += GameOver;
        _playerController.OnFindExit += GameCompleted;
    }

    private void OnDestroy()
    {
        _playerController.OnTorchTurnOff -= GameOver;
        _playerController.OnDeath -= GameOver;
        _playerController.OnFindExit -= GameCompleted;
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        _gameOverUI.SetActive(true);
    }

    private void GameCompleted()
    {
        Time.timeScale = 0;
        _gameCompletedUI.SetActive(true);
    }
}
