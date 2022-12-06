using UnityEngine;
using UnityEngine.Events;

public class PlayerExperience : MonoBehaviour
{
    [SerializeField] private int _currentLevel = 1;
    [SerializeField] private PlayerTalents _playerTalents;

    private int _maxLevel = 50;
    private int _currentExpirienceValue;
    private int _maxExpirienceValue = 100;

    public UnityAction<float, float> ChangeExperience;
    public UnityAction<int> ChangeLevel;

    private void Start()
    {
        ChangeExperience?.Invoke(_currentExpirienceValue, _maxExpirienceValue);
    }

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

            ChangeExperience?.Invoke(_currentExpirienceValue, _maxExpirienceValue);
        }
    }

    private void LevelUp()
    {
        _currentLevel++;
        _playerTalents.ShowTalentsPanel();
        ChangeLevel?.Invoke(_currentLevel);
    }
}
