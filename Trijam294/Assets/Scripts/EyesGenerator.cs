using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EyesGenerator : MonoBehaviour
{
    [SerializeField] private Eyes _eyes;
    [SerializeField] private PlayerController _player;
    [SerializeField] private int _numberOfEyes;
    [SerializeField] private Vector2 _xSpawnPos;
    [SerializeField] private Vector2 _ySpawnPos;
    [SerializeField] private int _spawnInterval;
    [SerializeField] private int _eyeLifeTime;


    private void Start()
    {
        Spawn();
    }

    private async void Spawn()
    {
        for (int i = 0; i < _numberOfEyes; i++)
        {
            SpawnEye();
            await Task.Delay(_spawnInterval);
        }
    }

    private void SpawnEye()
    {
        Eyes eye = Instantiate(_eyes);
        float posX = Random.Range(_xSpawnPos.x, _xSpawnPos.y);
        float posY = Random.Range(_ySpawnPos.x, _ySpawnPos.y);
        eye.gameObject.SetActive(true);
        eye.Initialize(_eyeLifeTime, _player);
        eye.gameObject.transform.position = new Vector3(posX, posY, 0);
        eye.OnDisapear += SpawnEye;
    }
}
