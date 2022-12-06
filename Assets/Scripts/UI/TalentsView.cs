using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TalentsView : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthLevelText;
    [SerializeField] private TMP_Text _energyLevelText;
    [SerializeField] private TMP_Text _rangeLevelText;
    [SerializeField] private TMP_Text _jumpLevelText;
    [SerializeField] private TMP_Text _currentHealthText;
    [SerializeField] private TMP_Text _currentEnergyText;
    [SerializeField] private TMP_Text _currentRangeText;
    [SerializeField] private TMP_Text _currentJumpText;
    [SerializeField] private PlayerTalents _playerTalents;

    private void OnEnable()
    {
        Render();
    }

    private void Render()
    {
        _healthLevelText.text = _playerTalents.HealthLevel.ToString();
        _energyLevelText.text = _playerTalents.EnergyLevel.ToString();
        _rangeLevelText.text = _playerTalents.RangeLevel.ToString();
        _jumpLevelText.text = _playerTalents.JumpLevel.ToString();
        _currentHealthText.text = _playerTalents.MaxHealt.ToString() + " Health";
        _currentEnergyText.text = _playerTalents.MaxEnergy.ToString() + " Energy";
        _currentRangeText.text = _playerTalents.MaxRange.ToString() + " meters laser";
        _currentJumpText.text = _playerTalents.JumpForce.ToString() + " meters jump";
    }
}
