using UnityEngine;
using UnityEngine.Events;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] private float _maxEnergy = 100f;
    [SerializeField] private float _stepTimeRestore = 0.5f;

    private float _restoreValue = 2f;
    private float _currentEnergy;
    private float _timeRemaining;
    private bool _canRestoreEnergy = false;
    private bool _isEmptyEnergy = false;

    public UnityAction<float, float> ChangeEnergy;

    public bool IsEmptyEnergy => _isEmptyEnergy;
    public float CurrentEnergy => _currentEnergy;
    public float MaxEnergy => _maxEnergy;

    private void Start()
    {
        _currentEnergy = _maxEnergy;
        ChangeEnergy?.Invoke(_currentEnergy, _maxEnergy);
    }

    private void Update()
    {
        if (_canRestoreEnergy || _isEmptyEnergy == true)
        {
            RestoreEnergyPerTime();
        }       
    }

    public void AddMaxEnergy(float value)
    {
        _maxEnergy += value;
        ChangeEnergy?.Invoke(_currentEnergy, _maxEnergy);
    }

    public void ResetMaxEnergy(float value)
    {
        _maxEnergy = value;
        ChangeEnergy?.Invoke(_currentEnergy, _maxEnergy);
    }

    public void DecreaseEnergy(float value)
    {
        StopRestoreEnergy();

        if (_currentEnergy > value)
        {
            _currentEnergy -= value;

            if(_currentEnergy <= value)
            {
                EmptyEnergy();
            }
        }
        else
        {
            EmptyEnergy();
        }

        ChangeEnergy?.Invoke(_currentEnergy, _maxEnergy);
    }

    public void StartRestoreEnergy()
    {
        _canRestoreEnergy = true;
    }

    public void StopRestoreEnergy()
    {
        _canRestoreEnergy = false;
    }

    private void EmptyEnergy()
    {
        _currentEnergy = 0;
        _isEmptyEnergy = true;
    }

    private void RestoreEnergyPerTime()
    {
        if (_currentEnergy < _maxEnergy)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            }
            else
            {
                _currentEnergy += _restoreValue;
                _timeRemaining = _stepTimeRestore;

                if (_currentEnergy >= _maxEnergy)
                {
                    _currentEnergy = _maxEnergy;
                    _isEmptyEnergy = false;
                    StopRestoreEnergy();
                }

                ChangeEnergy?.Invoke(_currentEnergy, _maxEnergy);
            }
        }
    }
}
