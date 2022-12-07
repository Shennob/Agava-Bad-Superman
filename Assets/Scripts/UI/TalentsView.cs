using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    [SerializeField] private Button _buttonHealth;
    [SerializeField] private Button _buttonEnergy;
    [SerializeField] private Button _buttonRange;
    [SerializeField] private Button _buttonJump;

    private PlayerTalents _playerTalents;

    private void Start()
    {
        _playerTalents = FindObjectOfType<PlayerTalents>();
        Render();
    }

    private void OnEnable()
    {
        Render();
        _buttonHealth.onClick.AddListener(OnClickHealthUp);
        _buttonEnergy.onClick.AddListener(OnClickEnergyUp);
        _buttonRange.onClick.AddListener(OnClickRangeUp);
        _buttonJump.onClick.AddListener(OnClickJumpUp);
    }

    private void OnDisable()
    {
        _buttonHealth.onClick.RemoveListener(OnClickHealthUp);
        _buttonEnergy.onClick.RemoveListener(OnClickEnergyUp);
        _buttonRange.onClick.RemoveListener(OnClickRangeUp);
        _buttonJump.onClick.RemoveListener(OnClickJumpUp);
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

    private void OnClickHealthUp()
    {
        _playerTalents.IncreaseHealth();
    }

    private void OnClickEnergyUp()
    {
        _playerTalents.IncreaseEnergy();
    }

    private void OnClickRangeUp()
    {
        _playerTalents.IncreaceRange();
    }

    private void OnClickJumpUp()
    {
        _playerTalents.IncreaseJump();
    }
}
