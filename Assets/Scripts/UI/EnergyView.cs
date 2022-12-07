using UnityEngine;

public class EnergyView : View
{
    [SerializeField] private PlayerEnergy _playerEnergy;

    private void Awake()
    {
        _playerEnergy = FindObjectOfType<PlayerEnergy>();
    }

    private void OnEnable()
    {
        _playerEnergy.ChangeEnergy += OnValueChanged;
    }

    private void OnDisable()
    {
        _playerEnergy.ChangeEnergy -= OnValueChanged;
    }
}
