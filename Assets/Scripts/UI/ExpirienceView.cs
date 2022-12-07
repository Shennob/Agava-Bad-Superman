using Opsive.Shared.Input;
using Opsive.UltimateCharacterController.Character;
using TMPro;
using UnityEngine;

public class ExpirienceView : View
{
    [SerializeField] private PlayerExperience _playerExperience;
    [SerializeField] private UnityInput _unityInput;
    [SerializeField] private TMP_Text _currentLevel;

    private void Awake()
    {
        _playerExperience = FindObjectOfType<PlayerExperience>();
        _unityInput = FindObjectOfType<UnityInput>();
    }

    private void OnEnable()
    {
        _playerExperience.ChangeExperience += OnValueChanged;
        _playerExperience.ChangeLevel += OnLevelChanged;
    }

    private void OnDisable()
    {
        _playerExperience.ChangeExperience -= OnValueChanged;
        _playerExperience.ChangeLevel -= OnLevelChanged;
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _unityInput.enabled = true;
    }

    private void OnLevelChanged(int currentLevel)
    {
        _currentLevel.text = currentLevel.ToString();
        _unityInput.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
