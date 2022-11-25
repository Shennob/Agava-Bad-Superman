using System;
using UnityEngine;

public class WantedLevel : MonoBehaviour
{
    [SerializeField] private int _pointToOneLevel;
    [SerializeField] private int _maxWantedLevel;

    private int _wantedPoints;
    private int _currentWantedLevel;
    private int _previousWantedLevel;

    public Action LevelChanged;

    private void Awake()
    {
        _wantedPoints = 0;
        _currentWantedLevel = 0;
        _previousWantedLevel = 0;
    }

    public void AddPoints(int value)
    {
        if(value < 0)
        {
            throw new ArgumentOutOfRangeException("Points can't be negative");
        }

        _wantedPoints += value;
        CalculateLevel();
    }

    private void CalculateLevel()
    {
        if (_currentWantedLevel == _maxWantedLevel)
        {
            return;
        }

        _currentWantedLevel = _wantedPoints / _pointToOneLevel;

        if(_currentWantedLevel > _previousWantedLevel)
        {
            LevelChanged?.Invoke();
            _previousWantedLevel = _currentWantedLevel;
        }        
    }
}
