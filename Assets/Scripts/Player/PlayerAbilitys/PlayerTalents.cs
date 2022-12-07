using Opsive.UltimateCharacterController.Character;
using Opsive.UltimateCharacterController.Character.Abilities;
using UnityEngine;

public class PlayerTalents : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerEnergy _playerEnergy;
    [SerializeField] private EyeLaser _eyeLaser;
    [SerializeField] private UltimateCharacterLocomotion _characterLocomotion;
    [SerializeField] private Transform _talentsHolder;

    private int _healthLevel = 1;
    private int _energyLevel = 1;
    private int _rangeLevel = 1;
    private int _jumpLevel = 1;
    private int _defaultLevel = 1;
    private float _defaultHealth;
    private float _defaultEnergy;
    private float _defaultRange;
    private float _defaultJumpForce;
    private float _increaseHealthValue = 10f;
    private float _increaseEnergyValue = 10f;
    private float _increaseRangeValue = 0.5f;
    private float _increaseJumpValue = 0.5f;
    private Jump _jumpAbility;

    public int HealthLevel => _healthLevel;
    public int EnergyLevel => _energyLevel;
    public int RangeLevel => _rangeLevel;
    public int JumpLevel => _jumpLevel;
    public float MaxHealt => _playerHealth.MaxHealth;
    public float MaxEnergy => _playerEnergy.MaxEnergy;
    public float MaxRange => _eyeLaser.MaxLength;
    public float JumpForce => _jumpAbility.Force;

    private void Awake()
    {
        _talentsHolder = FindObjectOfType<TalentsView>().GetComponent<Transform>();
    }

    private void Start()
    {
        _jumpAbility = _characterLocomotion.GetAbility<Jump>();
        _talentsHolder.gameObject.SetActive(false);
        _defaultHealth = _playerHealth.MaxHealth;
        _defaultEnergy = _playerEnergy.MaxEnergy;
        _defaultRange = _eyeLaser.MaxLength;
        _defaultJumpForce = _jumpAbility.Force;      
    }

    public void IncreaseHealth()
    {
        _healthLevel++;
        _playerHealth.AddMaxHealth(_increaseHealthValue);
        HideTalentsPanel();
    }

    public void IncreaseEnergy()
    {
        _energyLevel++;
        _playerEnergy.AddMaxEnergy(_increaseEnergyValue);
        HideTalentsPanel();
    }

    public void IncreaceRange()
    {
        _rangeLevel++;
        _eyeLaser.AddMaxLength(_increaseRangeValue);
        HideTalentsPanel();
    }

    public void IncreaseJump()
    {
        _jumpLevel++;
        _jumpAbility.Force += _increaseJumpValue;
        HideTalentsPanel();
    }

    public void ShowTalentsPanel()
    {
        _talentsHolder.gameObject.SetActive(true);
    }

    public void ResetTalents()
    {
        _healthLevel = _defaultLevel;
        _energyLevel = _defaultLevel;
        _rangeLevel = _defaultLevel;
        _jumpLevel = _defaultLevel;
        _playerHealth.ResetMaxHealth(_defaultHealth);
        _playerEnergy.ResetMaxEnergy(_defaultEnergy);
        _eyeLaser.ResetMaxLength(_defaultRange);
        _jumpAbility.Force = _defaultJumpForce;
    }

    private void HideTalentsPanel()
    {
        _talentsHolder.gameObject.SetActive(false);
    }
}
