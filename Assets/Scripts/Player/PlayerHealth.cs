using BehaviorDesigner.Runtime.Tactical;
using Opsive.UltimateCharacterController.Traits;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private const string IsDie = "IsDie";

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterRespawner _respawner;
    [SerializeField] private float _respawnTime;
    [SerializeField] private WantedLevel _wantedLevel;
    [SerializeField] private PlayerTalents _playerTalents;

    private bool _isAlive = true;

    public float MaxHealth => _maxHealth;
    public float Health => _health;

    public void AddMaxHealth(float value)
    {
        _maxHealth += value;
        _health = _maxHealth;
    }

    public void ResetMaxHealth(float value)
    {
        _maxHealth = value;
    }

    public void Damage(float amount)
    {
        _health -= amount;

        if(_health <= 0)
        {
            Die();
            _isAlive = false;
        }
    }

    public bool IsAlive()
    {
        return _isAlive;
    }

    private void Die()
    {
        _animator.SetBool(IsDie, true);
        StartCoroutine(RespawnWithDelay());
    }

    private IEnumerator RespawnWithDelay()
    {
        yield return new WaitForSeconds(_respawnTime);
        _respawner.Respawn();
        _wantedLevel.ResetWantedLevel();
        _playerTalents.ResetTalents();
        _animator.SetBool(IsDie, false);
        _health = _maxHealth;
    }
}
