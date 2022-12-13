using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PeopleHealth : MonoBehaviour, IHitable
{
    private const string IsDie = "IsDie";

    [SerializeField] private float _maxHealth = 20f;
    [SerializeField] private Animator _animator;
    [SerializeField] private int _wantedPointsToAdd;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private LootNote _lootNote;

    private float _currentHealth;
    private int _expirienceValue = 50;
    private WantedLevel _wantedLevel;
    private PlayerExperience _playerExperience;
    private HumanSpawner _humanSpawner;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _wantedLevel = FindObjectOfType<WantedLevel>();
        _humanSpawner = FindObjectOfType<HumanSpawner>();
        _playerExperience = FindObjectOfType<PlayerExperience>();
        //_navMeshAgent.isStopped = false;
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
                _navMeshAgent.isStopped = true;
                _animator.SetBool(IsDie, true);
                AddWantedPoints();
                AddExpirience();
                _lootNote.DroopLoot();
                StartCoroutine(DestroyWithDelay());
            }
        }
    }

    public void AddWantedPoints()
    {
        if (_wantedLevel.CurrentWantedLevel == 5)
            return;

        //if (_wantedLevel.CurrentWantedLevel >= 2)
        //{
        _wantedLevel.AddPoints(_wantedPointsToAdd);
        //}
        //else
        //{
        //_wantedLevel.SetWantedLevel(2);
        //}
    }

    private IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(3f);
        _humanSpawner.Spawn();
        Destroy(gameObject);
    }

    public void AddExpirience()
    {
        _playerExperience.AddExpirience(_expirienceValue);
    }
}
