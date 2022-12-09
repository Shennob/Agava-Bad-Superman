using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WantedLevel : MonoBehaviour
{
    [SerializeField] private int _pointToOneLevel;
    [SerializeField] private int _maxWantedLevel;
    [SerializeField] private GameObject _starPanel;
    [SerializeField] private float _cooldownForOneStar;
    [SerializeField] private float _cooldownTwoStar;
    [SerializeField] private float _cooldownForThreeStar;
    [SerializeField] private float _cooldownForFourStars;
    [SerializeField] private float _cooldownForFiveStars;

    private int _wantedPoints;
    private int _currentWantedLevel;
    private int _previousWantedLevel;
    private bool _isTimerStart = false;
    private float _currentTime;
    private float _timeToDisableStar;
    private int _destroyedCar;

    public int CurrentWantedLevel => _currentWantedLevel;

    public Action<int> IncreaseLevel;
    public Action<int> DecreaseLevel;

    private void Awake()
    {
        _starPanel = FindObjectOfType<WantedStarView>().gameObject;
        ResetWantedLevel();  
    }

    private void Update()
    {
        if(_isTimerStart == false)
        {
            return;
        }

        Debug.Log(_currentWantedLevel);

        _currentTime += Time.deltaTime;

        if(_currentTime >= _timeToDisableStar)
        {
  
            DecreaseLevel?.Invoke(_currentWantedLevel);

            if(_currentWantedLevel > 1)
            {
                DestroyOneStar();
            }
            else
            {
                _currentWantedLevel = 0;
                DisableStars();
            }          
        }
    }

    public void AddPoints(int value)
    {
        if (_currentWantedLevel == _maxWantedLevel)
        {
            return;
        }

        if (value < 0)
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
        _destroyedCar = 0;
        DisableStars();
    }

    public void SetWantedLevel(int level)
    {
        if(_currentWantedLevel == _maxWantedLevel)
        {
            return;
        }

        if(_currentWantedLevel > 0)
        {
            DisableStars();
        }

        _currentWantedLevel = level;

        for (int i = 0; i < _currentWantedLevel; i++)
        {
            IncreaseLevel?.Invoke(_currentWantedLevel);
            _previousWantedLevel = _currentWantedLevel;
        }

        if(_currentWantedLevel == 1)
        {
            _timeToDisableStar = Time.time + _cooldownForOneStar;
            _isTimerStart = true;
        }
        else if(_currentWantedLevel == 2)
        {
            _timeToDisableStar = Time.time + _cooldownTwoStar;
            _isTimerStart = true;
        }
        else if(_currentWantedLevel == 3)
        {
            _timeToDisableStar = Time.time + _cooldownForThreeStar;
            _isTimerStart = true;
        }
        else if(_currentWantedLevel == 4)
        {
            _timeToDisableStar = Time.time + _cooldownForFourStars;
            _isTimerStart = true;
        }
        else if(_currentWantedLevel == 5)
        {
            _timeToDisableStar = Time.time + _cooldownForFiveStars;
            _isTimerStart = true;
        }
    }

    private void DisableStars()
    {
        var stars = _starPanel.GetComponentInChildren<Transform>();

        foreach (Transform star in stars)
        {
            Destroy(star.gameObject);
        }
    }

    public void UpDestroyedCar()
    {
        _destroyedCar++;

        if(_destroyedCar == 1)
        {
            SetWantedLevel(4);
        }
        else if(_destroyedCar == 3)
        {
            SetWantedLevel(5);
        }
    }

    private void DestroyOneStar()
    {
        var stars = _starPanel.GetComponentsInChildren<Transform>();
        var star = stars[^1];
        _currentWantedLevel--;

        if (_currentWantedLevel == 1)
        {
            _timeToDisableStar = Time.time + _cooldownForOneStar;
            _isTimerStart = true;
        }
        else if (_currentWantedLevel == 2)
        {
            _timeToDisableStar = Time.time + _cooldownTwoStar;
            _isTimerStart = true;
        }
        else if (_currentWantedLevel == 3)
        {
            _timeToDisableStar = Time.time + _cooldownForThreeStar;
            _isTimerStart = true;
        }
        else if (_currentWantedLevel == 4)
        {
            _timeToDisableStar = Time.time + _cooldownForFourStars;
            _isTimerStart = true;
        }
        else if (_currentWantedLevel == 5)
        {
            _timeToDisableStar = Time.time + _cooldownForFiveStars;
            _isTimerStart = true;
        }

        Destroy(star.gameObject);
    }
}
