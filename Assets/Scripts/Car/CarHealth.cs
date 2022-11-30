using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHealth : MonoBehaviour, IHitable
{
    [SerializeField] private float _health;
    [SerializeField] private ParticleSystem _explouseianParticle;
    [SerializeField] private Rigidbody _carRigidbody;
    [SerializeField] private Rigidbody _firstLeftVehicle;
    [SerializeField] private Rigidbody _secondLeftVehicle;
    [SerializeField] private Rigidbody _firstRightVehicle;
    [SerializeField] private Rigidbody _seocndRifgtVehicle;
    [SerializeField] private MeshRenderer _carMeshRenderer;
    [SerializeField] private Material _explouseionMaterial;
    [SerializeField] private Vector3 _carExplouseVector;
    [SerializeField] private Vector3 _rightVechicleExplouseForce;
    [SerializeField] private Vector3 _leftVechicleExplouseForce;
    [SerializeField] private float _cooldownDestroy;
    [SerializeField] private ParticleSystem _fireParticle;
    [SerializeField] private GameObject[] _disableObject;
    [SerializeField] private float _enableFireDelay;
    [SerializeField] private int _wantedPointsToAdd;
    [SerializeField] private SplineSeter _splineSeter;

    private bool _isExplouse = false;
    private WantedLevel _wantedLevel;

    private void Awake()
    {
        _wantedLevel = FindObjectOfType<WantedLevel>();
    }

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
        if(_isExplouse == true)
        {
            return;
        }

        _carRigidbody.isKinematic = false;
        _firstLeftVehicle.isKinematic = false;
        _firstRightVehicle.isKinematic = false;
        _secondLeftVehicle.isKinematic = false;
        _seocndRifgtVehicle.isKinematic = false;
        _carRigidbody.AddForce(_carExplouseVector);
        _firstLeftVehicle.AddForce(_leftVechicleExplouseForce);
        _secondLeftVehicle.AddForce(_leftVechicleExplouseForce);
        _firstRightVehicle.AddForce(_rightVechicleExplouseForce);
        _secondLeftVehicle.AddForce(_rightVechicleExplouseForce);
        _carMeshRenderer.material = _explouseionMaterial;

        foreach(var disableObject in _disableObject)
        {
            disableObject.SetActive(false);
        }

        _explouseianParticle.Play();
        StartCoroutine(DestroyWithDelay());
        StartCoroutine(EnableFireWithDelay());
        AddWantedPoints();
        _splineSeter.StopMovement();
        _isExplouse = true;
    }

    private IEnumerator EnableFireWithDelay()
    {
        yield return new WaitForSeconds(_enableFireDelay);
        _fireParticle.Play();
    }

    private IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(_cooldownDestroy);
        Destroy(gameObject);
    }

    private IEnumerator TestDelay()
    {
        yield return new WaitForSeconds(5f);
        Explouse();
    }

    public void AddWantedPoints()
    {
        _wantedLevel.AddPoints(_wantedPointsToAdd);
    }
}
