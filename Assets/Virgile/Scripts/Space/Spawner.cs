using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Fields
    [Header("Game Objects")]
    [SerializeField] private Transform _meteoriteContainer = null;
    [Header("Array")]
    [SerializeField] private Transform[] _spawnPos = null;
    [SerializeField] private GameObject[] _meteorite = null;
    [Header("Misc")]
    [SerializeField] private float _delay = 5f;
    private float _timeStamp = 0;
    #endregion Fields

    #region Methods
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        _timeStamp += Time.deltaTime;
        if (_timeStamp >= _delay)
        {
            int meteoriteIndex = Random.Range(0, _meteorite.Length);
            int spawnIndex = Random.Range(0, _spawnPos.Length);
            Instantiate(_meteorite[meteoriteIndex], _spawnPos[spawnIndex].position, Quaternion.identity, _meteoriteContainer);
            _timeStamp = 0;
        }
    }
    #endregion Methods
}
