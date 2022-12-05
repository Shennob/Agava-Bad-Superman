using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, IHitable
{
    [SerializeField] private float _health;
    [SerializeField] private float _respawnTime;
    [SerializeField] private ParticleSystem _smoke;
    [SerializeField] private Material _destroyedMaterial;
    [SerializeField] private ParticleSystem _fireParticle;
    [SerializeField] private int _wantedPointsToAdd;
    [SerializeField] private int _expirienceValue;

    private PlayerExperience _playerExperience;
    private Material _startMaterial;
    private MeshRenderer _meshRenderer;
    private WantedLevel _wantedLevel;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _startMaterial = _meshRenderer.material;
        _wantedLevel = FindObjectOfType<WantedLevel>();
        _playerExperience = FindObjectOfType<PlayerExperience>();
    }

    public void AddExpirience()
    {
        _playerExperience.AddExpirience(_expirienceValue);
    }

    public void AddWantedPoints()
    {
        if (_wantedLevel.CurrentWantedLevel > 2)
        {
            _wantedLevel.AddPoints(_wantedPointsToAdd);
        }
        else
        {
            _wantedLevel.SetWantedLevel(2);
        }
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        _meshRenderer.material = _destroyedMaterial;
        //_smoke.gameObject.SetActive(true);
        _fireParticle.gameObject.SetActive(true);
        StartCoroutine(RenewBuildingWithDelay());
    }

    private IEnumerator RenewBuildingWithDelay()
    {
        yield return new WaitForSeconds(_respawnTime);
        _fireParticle.gameObject.SetActive(false);
        _meshRenderer.material = _startMaterial;
    }
}
