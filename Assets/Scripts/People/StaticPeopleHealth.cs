using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPeopleHealth : MonoBehaviour, IHitable
{
    private const string IsDie = "IsDie";

    [SerializeField] private float _maxHealth = 20f;
    [SerializeField] private Animator _animator;
    [SerializeField] private int _wantedPointsToAdd;
    [SerializeField] private LootNote _lootNote;

    private float _currentHealth;
    private int _expirienceValue = 50;
    private WantedLevel _wantedLevel;
    private PlayerExperience _playerExperience;
    private StaticPeopleSpawner _staticPeopleSpawner;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _wantedLevel = FindObjectOfType<WantedLevel>();
        _playerExperience = FindObjectOfType<PlayerExperience>();
        _staticPeopleSpawner = FindObjectOfType<StaticPeopleSpawner>();
    }

    public void AddExpirience()
    {
        _playerExperience.AddExpirience(_expirienceValue);
    }

    public void AddWantedPoints()
    {
        if (_wantedLevel.CurrentWantedLevel == 5)
            return;

        _wantedLevel.AddPoints(_wantedPointsToAdd);
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
                AddExpirience();
                _lootNote.DroopLoot();
                StartCoroutine(DestroyWithDelay());
            }
        }
    }

    private IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(3f);
        _staticPeopleSpawner.Spawn(gameObject, _animator);
        gameObject.SetActive(false);      
    }
}
