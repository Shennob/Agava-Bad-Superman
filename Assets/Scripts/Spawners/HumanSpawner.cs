using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] private PeopleHealth[] _peoplesTemplates;
    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private float _cooldownToSpawn;

    //private PlayerHealth _playerHealth;

    //private void Awake()
    //{
    //    _playerHealth = FindObjectOfType<PlayerHealth>();
    //}

    public void Spawn()
    {
        StartCoroutine(SpawnWithDelay());
    }

    private IEnumerator SpawnWithDelay()
    {
        yield return new WaitForSeconds(_cooldownToSpawn);
        BehaviorTreePlayerSeter _spawnHuman =  Instantiate(_peoplesTemplates[Random.Range(0, _peoplesTemplates.Length - 1)], _spawnPoints[Random.Range(0, _spawnPoints.Length - 1)].transform.position, Quaternion.identity).GetComponent<BehaviorTreePlayerSeter>();
        //_spawnHuman.PlayerSeter(_playerHealth.gameObject);
    }
}
