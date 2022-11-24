using UnityEngine;
using UnityEngine.UI;

public class EnergyView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private PlayerEnergy _playerEnergy;

    private void Awake()
    {
        _slider.value = 1;
    }

    private void OnEnable()
    {
        _playerEnergy.ChangeEnergy += OnEnergyChanged;
    }

    private void OnDisable()
    {
        _playerEnergy.ChangeEnergy -= OnEnergyChanged;
    }

    private void OnEnergyChanged(float currentEnergy, float maxEnergy)
    {
        _slider.value = currentEnergy / maxEnergy;
    }
}
