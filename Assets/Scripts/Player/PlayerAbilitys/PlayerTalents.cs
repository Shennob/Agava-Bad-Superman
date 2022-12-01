using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTalents : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerEnergy _playerEnergy;
    [SerializeField] private Transform _talentsHolder;

    private int _healthLevel = 1;
    private int _energyLevel = 1;
    private int _jumpLevel = 1;

    public void IncreaseHealth()
    {
        _healthLevel++;
    }

    public void ShowTalentsPanel()
    {
        Time.timeScale = 0;
        _talentsHolder.gameObject.SetActive(true);
    }
}
