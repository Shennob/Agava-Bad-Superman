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

    public UnityAction<float, float> ChangeEnergy;

    public float CurrentEnergy => _currentEnergy;

    private void Start()
    {
        _currentEnergy = _maxEnergy;
    }

    private void Update()
    {
        if (_canRestoreEnergy)
        {
            RestoreEnergyPerTime();
        }
    }

    public void DecreaseEnergy(float value)
    {
        StopRestoreEnergy();

        if (_currentEnergy > 0)
        {
            _currentEnergy -= value;
        }
        else
        {
            _currentEnergy = 0;
        }
    }

    public void StartRestoreEnergy()
    {
        _canRestoreEnergy = true;
    }

    public void StopRestoreEnergy()
    {
        _canRestoreEnergy = false;
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
                    StopRestoreEnergy();
                }
            }
        }
    }
}
