using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
    [SerializeField] private PoliceCar _policeCar;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private CarSpawner[] _carSpawners;
 
    private bool _isExplouse = false;
    private int _expirienceValue = 50;
    private WantedLevel _wantedLevel;
    private PlayerExperience _playerExperience;

    private void Start()
    {
        _wantedLevel = FindObjectOfType<WantedLevel>();
        _playerExperience = FindObjectOfType<PlayerExperience>();
        _carSpawners = FindObjectsOfType<CarSpawner>();
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
        AddExpirience();
        _splineSeter.StopMovement();

        if(_policeCar != null)
        {
            _policeCar.DestroyCar();
        }

        _audioSource.Play();
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
        int id = Random.Range(0, _carSpawners.Length - 1);
        _carSpawners[id].Spawn();
        Destroy(gameObject);
    }

    private IEnumerator TestDelay()
    {
        yield return new WaitForSeconds(5f);
        Explouse();
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
        //    _wantedLevel.SetWantedLevel(2);
        //}
    }

    public void AddExpirience()
    {
        _playerExperience.AddExpirience(_expirienceValue);
    }
}
