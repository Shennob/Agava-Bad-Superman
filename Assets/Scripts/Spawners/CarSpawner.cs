using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] private CarHealth[] _carsTemplates;
    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private float _cooldownToSpawn;
    [SerializeField] private SplineSeter _splineSeter;

    public void Spawn()
    {
        StartCoroutine(SpawnWithDelay());
    }

    private IEnumerator SpawnWithDelay()
    {
        yield return new WaitForSeconds(_cooldownToSpawn);
        var car =  Instantiate(_carsTemplates[Random.Range(0, _carsTemplates.Length - 1)], _spawnPoints[Random.Range(0, _spawnPoints.Length - 1)].transform.position, Quaternion.identity);
        _splineSeter.SetSpline(car.GetComponent<SplineFollower>());
    }
}
