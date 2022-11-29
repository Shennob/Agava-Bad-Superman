using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public float TimeToSpawnPolice;
}

public class PoliceSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] private List<Wave> _wantedWaves;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private PeopleHealth[] _policeTemplates;
    [SerializeField] private WantedLevel _wantedLevel;

    private bool _containsWantedLevel = false;
    private float _currentTimeToSpawn;
    private float _timeRemaining;

    private void OnEnable()
    {
        _wantedLevel.LevelChange += OnLevelChanged;
    }

    private void Update()
    {
        if (_containsWantedLevel)
        {
            Spawn();
        }
    }

    private void OnDisable()
    {
        _wantedLevel.LevelChange -= OnLevelChanged;
    }

    public void Spawn()
    {
        if (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
        }
        else
        {
            _timeRemaining = _currentTimeToSpawn;

            for (int i = 0; i < _spawnPoints.Count; i++)
            {
                Instantiate(_policeTemplates[Random.Range(0, _policeTemplates.Length - 1)], _spawnPoints[i].transform.position, Quaternion.identity);
            }
        }
    }

    private void OnLevelChanged(int wantedLevel)
    {
        _containsWantedLevel = true;
        _currentTimeToSpawn = _wantedWaves[wantedLevel - 1].TimeToSpawnPolice;
        _timeRemaining = _currentTimeToSpawn;
    }
}
