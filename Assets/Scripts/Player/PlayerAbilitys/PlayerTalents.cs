using Opsive.UltimateCharacterController.Character;
using Opsive.UltimateCharacterController.Character.Abilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTalents : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerEnergy _playerEnergy;
    [SerializeField] private UltimateCharacterLocomotion _characterLocomotion;
    [SerializeField] private Transform _talentsHolder;

    private int _healthLevel = 1;
    private int _energyLevel = 1;
    private int _jumpLevel = 1;
    private float _increaseHealthValue = 10f;
    private float _increaseEnergyValue = 10f;

    private void Start()
    {
        var jumpAbility = _characterLocomotion.GetAbility<Jump>();
        //jumpAbility.Force += 100;
    }

    public void IncreaseHealth()
    {
        _healthLevel++;
        _playerHealth.SetMaxHealth(_increaseHealthValue);
        HideTalentsPanel();
    }

    public void IncreaseEnergy()
    {
        _energyLevel++;
        _playerEnergy.SetMaxEnergy(_increaseEnergyValue);
        HideTalentsPanel();
    }

    public void ShowTalentsPanel()
    {
        Time.timeScale = 0;
        _talentsHolder.gameObject.SetActive(true);
    }

    private void HideTalentsPanel()
    {
        Time.timeScale = 1;
        _talentsHolder.gameObject.SetActive(false);
    }
}
