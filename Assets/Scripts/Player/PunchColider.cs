using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchColider : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out PeopleHealth peopleHealth))
        {
            peopleHealth.ApplyDamage(_damage);
        }
    }
}
