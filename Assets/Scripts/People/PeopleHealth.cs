using System;
using UnityEngine;

public class PeopleHealth : MonoBehaviour
{
    private const string IsDie = "IsDie";

    [SerializeField] private float _maxHealth = 20f;
    [SerializeField] private Animator _animator;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        if (damage < 0)
        {
            throw new ArgumentOutOfRangeException("Damage can't be negative");
        }

        if (_currentHealth > 0f)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                _animator.SetBool(IsDie, true);
            }
        }
    }
}
