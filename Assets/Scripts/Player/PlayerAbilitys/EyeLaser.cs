using System.Collections.Generic;
using UnityEngine;

public class EyeLaser : MonoBehaviour
{
    [SerializeField] private Transform[] _firePoints;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxLength;
    [SerializeField] private GameObject _effectTemplate;
    [SerializeField] private float _damage = 3f;
    [SerializeField] private float _timePerHit = 0.3f;
    [SerializeField] private PlayerEnergy _playerEnergy;
    [SerializeField] private float _energyCost = 5f;
    [SerializeField] private LayerMask _ignoreMask;

    private bool _readyToShoot = false;
    private float _timeRemaining;
    private float _minTimeRemaining = 0.01f;
    private Vector3 _direction;
    private Quaternion _rotation;
    private List<GameObject> _instances = new List<GameObject>();

    void Update()
    {
        RotateToMouseDirection();

        if (Input.GetMouseButtonDown(0))
        {
            CreateLaser();
        }

        if (Input.GetMouseButton(1))
        {
            _readyToShoot = true;
        }

        if (Input.GetMouseButton(0))
        {
            CreateRay();
        }

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            DestroyLaser();
        }
    }

    private void CreateLaser()
    {
        _playerEnergy.StopRestoreEnergy();

        if (_readyToShoot && _playerEnergy.CurrentEnergy >= _energyCost)
        {
            for (int i = 0; i < _firePoints.Length; i++)
            {
                var laser = Instantiate(_effectTemplate, _firePoints[i].position, _firePoints[i].rotation);
                laser.transform.parent = _firePoints[i];
                _instances.Add(laser);
            }
        }
    }

    private void CreateRay()
    {
        if (_readyToShoot && _playerEnergy.CurrentEnergy >= _energyCost)
        {
            RaycastHit hit;
            Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            _direction = ray.direction;

            if (_timeRemaining > _minTimeRemaining)
            {
                _timeRemaining -= Time.deltaTime;
            }
            else
            {
                if (Physics.Raycast(ray.origin, _direction, out hit, _maxLength, ~_ignoreMask))
                {
                    if (hit.collider.TryGetComponent(out IHitable hitable))
                    {
                        hitable.ApplyDamage(_damage);
                    }
                }

                _timeRemaining = _timePerHit;
                _playerEnergy.DecreaseEnergy(_energyCost);
            }

            _playerEnergy.StopRestoreEnergy();
        }
    }

    private void DestroyLaser()
    {
        for (int i = 0; i < _firePoints.Length; i++)
        {
            if (_instances.Count >= 1)
            {
                Destroy(_instances[i]);
            }
        }

        _readyToShoot = false;
        _instances.Clear();
        _playerEnergy.StartRestoreEnergy();
    }

    private void RotateToMouseDirection()
    {
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        _direction = ray.direction;
        _rotation = Quaternion.LookRotation(_direction);
        transform.rotation = _rotation;
    }
}
