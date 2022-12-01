using System;
using System.Collections.Generic;
using UnityEngine;

public class WantedLevel : MonoBehaviour
{
    [SerializeField] private int _pointToOneLevel;
    [SerializeField] private int _maxWantedLevel;
    [SerializeField] private GameObject _starPanel;
    [SerializeField] private float _cooldownForOneStar;
    [SerializeField] private float _cooldownTwoStar;
    [SerializeField] private float _cooldownForThreeStar;

    private int _wantedPoints;
    private int _currentWantedLevel;
    private int _previousWantedLevel;
    private bool _isTimerStart = false;
    private float _currentTime;
    private float _timeToDisableStar;

    public int CurrentWantedLevel => _currentWantedLevel;

    public Action<int> IncreaseLevel;
    public Action<int> DecreaseLevel;

    private void Awake()
    {
        ResetWantedLevel();
    }

    private void Update()
    {
        if(_isTimerStart == false)
        {
            return;
        }

        _currentTime += Time.deltaTime;

        if(_currentTime >= _timeToDisableStar)
        {
            _currentWantedLevel = 0;
            DisableStars();
        }
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
            IncreaseLevel?.Invoke(_currentWantedLevel);
            _previousWantedLevel = _currentWantedLevel;
        }        
    }

    public void ResetWantedLevel()
    {
        _wantedPoints = 0;
        _currentWantedLevel = 0;
        _previousWantedLevel = 0;
        DisableStars();
    }

    public void SetWantedLevel(int level)
    {
        _currentWantedLevel = level;

        DisableStars();

        for (int i = 0; i < _currentWantedLevel; i++)
        {
            IncreaseLevel?.Invoke(_currentWantedLevel);
            _previousWantedLevel = _currentWantedLevel;
        }

        if(_currentWantedLevel == 1)
        {
            _timeToDisableStar = Time.time + _cooldownForOneStar;
        }
        else if(_currentWantedLevel == 2)
        {
            _timeToDisableStar = Time.time + _cooldownTwoStar;
        }
        else if(_currentWantedLevel == 3)
        {
            _timeToDisableStar = Time.time + _cooldownForThreeStar;
        }

        _isTimerStart = true;
    }

    private void DisableStars()
    {
        var stars = _starPanel.GetComponentInChildren<Transform>();

        foreach (Transform star in stars)
        {
            Destroy(star.gameObject);
        }
    }
}
