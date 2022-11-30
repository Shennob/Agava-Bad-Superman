using BehaviorDesigner.Runtime.Tactical;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health;

    private bool _isAlive = true;

    public void Damage(float amount)
    {
        _health -= amount;

        if(_health <= 0)
        {
            _isAlive = false;
        }
    }

    public bool IsAlive()
    {
        return _isAlive;
    }
}
