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

    private bool _isAlive = true;

    public void SetMaxHealth(float value)
    {
        _maxHealth += value;
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
        _health = _maxHealth;
        _wantedLevel.ResetWantedLevel();
        _animator.SetBool(IsDie, false);
    }
}
