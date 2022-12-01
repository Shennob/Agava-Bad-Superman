using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    [SerializeField] private int _currentLevel = 1;
    [SerializeField] private PlayerTalents _playerTalents;

    private int _maxLevel = 50;
    private int _currentExpirienceValue;
    private int _maxExpirienceValue = 100;

    public void AddExpirience(int value)
    {
        if (_currentLevel != _maxLevel)
        {
            if (_currentExpirienceValue + value >= _maxExpirienceValue)
            {
                LevelUp();
                _currentExpirienceValue = _currentExpirienceValue + value - _maxExpirienceValue;
            }
            else
            {
                _currentExpirienceValue += value;
            }
        }
    }

    private void LevelUp()
    {
        _currentLevel++;
        _playerTalents.ShowTalentsPanel();
    }
}
