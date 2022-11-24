using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHealth : MonoBehaviour, IHitable
{
    [SerializeField] private float _health;
    [SerializeField] private ParticleSystem _explouseianParticle;

    public void ApplyDamage(float damage)
    {
        if (damage < 0)
        {
            throw new ArgumentOutOfRangeException("Damage can't be negative");
        }

        _health -= damage;

        if (_health <= 0)
        {
            Explouse();
        }
    }

    private void Explouse()
    {
        _explouseianParticle.Play();
    }
}
