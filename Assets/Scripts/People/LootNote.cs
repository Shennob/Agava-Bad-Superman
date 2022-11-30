using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootNote : MonoBehaviour
{
    [SerializeField] private List<WadOfMoney> _loots = new List<WadOfMoney>();

    private Vector3 _previousSpawnPoint;

    public void DroopLoot()
    {
        _previousSpawnPoint = transform.position;

        foreach(var loot in _loots)
        {
          var spawnObject =  Instantiate(loot, new Vector3(_previousSpawnPoint.x + Random.Range(2, 3), _previousSpawnPoint.y, _previousSpawnPoint.z + Random.Range(2, 3)), Quaternion.identity);
            _previousSpawnPoint = spawnObject.transform.position;
        }
    }
}
