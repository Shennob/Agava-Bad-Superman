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
    [SerializeField] private ParticleSystem _decalParticle;

    private Ray _ray;
    private float _timeRemaining;
    private Vector3 _direction;
    private Vector3 _offset = new Vector3(0.5f, 0.5f, 0);
    private List<GameObject> _instances = new List<GameObject>();

    public float MaxLength => _maxLength;

    void Update()
    {
        RotateToMouseDirection();

        if (Input.GetMouseButton(1))
        {
            CreateRay();
        }

        if (Input.GetMouseButtonUp(1) || ContainsEnergy() == false)
        {
            DestroyLaser();
        }
    }

    public void AddMaxLength(float value)
    {
        _maxLength += value;
    }

    public void ResetMaxLength( float value)
    {
        _maxLength = value;
    }

    private void CreateLaser()
    {
        _playerEnergy.StopRestoreEnergy();

        if (ContainsEnergy())
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
        if (ContainsEnergy())
        {
            RaycastHit hit;

            if (Physics.Raycast(_ray.origin, _direction, out hit, _maxLength, ~_ignoreMask))
            {              
                Debug.Log(hit.transform.name);

                if (hit.transform.tag == "Dirt")
                {
                    Instantiate(_decalParticle, hit.point,
                        Quaternion.LookRotation(hit.normal));
                }
            }

            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            }
            else
            {
                if (Physics.Raycast(_ray.origin, _direction, out hit, _maxLength, ~_ignoreMask))
                {
                    if (hit.collider.TryGetComponent(out IHitable hitable))
                    {
                        hitable.ApplyDamage(_damage);
                    }             
                }

                _timeRemaining = _timePerHit;
                _playerEnergy.DecreaseEnergy(_energyCost);
            }

            if (_instances.Count == 0)
            {
                CreateLaser();
            }
        }

        _playerEnergy.StopRestoreEnergy();
    }

    private bool ContainsEnergy()
    {
        return _playerEnergy.CurrentEnergy >= _energyCost && _playerEnergy.IsEmptyEnergy == false;
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

        _instances.Clear();
        _playerEnergy.StartRestoreEnergy();
    }

    private void RotateToMouseDirection()
    {
        _ray = _camera.ViewportPointToRay(_offset);
        _direction = _ray.direction;
        transform.rotation = Quaternion.LookRotation(_direction);
    }
}
