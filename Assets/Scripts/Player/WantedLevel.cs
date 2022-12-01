using System;
using UnityEngine;

public class WantedLevel : MonoBehaviour
{
    [SerializeField] private int _pointToOneLevel;
    [SerializeField] private int _maxWantedLevel;
    [SerializeField] private GameObject _starPanel;

    private int _wantedPoints;
    private int _currentWantedLevel;
    private int _previousWantedLevel;

    public int CurrentWantedLevel => _currentWantedLevel;

    public Action<int> LevelChange;

    private void Awake()
    {
        ResetWantedLevel();
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
            LevelChange?.Invoke(_currentWantedLevel);
            _previousWantedLevel = _currentWantedLevel;
        }        
    }

    public void ResetWantedLevel()
    {
        _wantedPoints = 0;
        _currentWantedLevel = 0;
        _previousWantedLevel = 0;
        var stars = _starPanel.GetComponentInChildren<Transform>();

        foreach(Transform star in stars)
        {
            Destroy(star.gameObject);
        }
    }
}
