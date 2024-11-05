using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _exitPlaces = new List<GameObject>();
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private GameObject _gameCompletedUI;

    private bool _gameOver = false;

    private void Start()
    {
        InitializeExitLocation();
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
        if (_gameOver)
        {
            return;
        }

        //Time.timeScale = 0;
        _playerController.StopMovement();
        _gameOverUI.SetActive(true);
    }

    private void GameCompleted()
    {
        _gameOver = true;
        //Time.timeScale = 0;
        _playerController.StopMovement();
        _gameCompletedUI.SetActive(true);
    }

    private void InitializeExitLocation()
    {
        int random = Random.Range(0, _exitPlaces.Count - 1);
        _exitPlaces[random].SetActive(true);
    }
}
