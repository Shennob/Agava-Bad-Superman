using System;
using UnityEngine;

public class PeopleHealth : MonoBehaviour, IHitable
{
    private const string IsDie = "IsDie";

    [SerializeField] private float _maxHealth = 20f;
    [SerializeField] private Animator _animator;
    [SerializeField] private int _wantedPointsToAdd;

    private float _currentHealth;
    private WantedLevel _wantedLevel;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _wantedLevel = FindObjectOfType<WantedLevel>();
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
                AddWantedPoints();
            }
        }
    }

    public void AddWantedPoints()
    {
        _wantedLevel.AddPoints(_wantedPointsToAdd);
    }
}
