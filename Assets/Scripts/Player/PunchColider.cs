using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchColider : MonoBehaviour
{
    [SerializeField] private float _damage;

    private WantedLevel _wantedLevel;

    private void Awake()
    {
        _wantedLevel = FindObjectOfType<WantedLevel>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out PeopleHealth peopleHealth))
        {
            if(_wantedLevel.CurrentWantedLevel < 1)
            {
                _wantedLevel.SetWantedLevel(1);
            }
          
            peopleHealth.ApplyDamage(_damage);
        }
    }
}
