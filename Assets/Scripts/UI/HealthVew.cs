using UnityEngine;

public class HealthVew : View
{
    [SerializeField] private PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnEnable()
    {
        _playerHealth.ChangeHealth += OnValueChanged;
    }

    private void OnDisable()
    {
        _playerHealth.ChangeHealth -= OnValueChanged;
    }
}
