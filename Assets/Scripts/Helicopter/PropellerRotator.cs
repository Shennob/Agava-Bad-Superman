using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerRotator: MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private void Update()
    {
        transform.Rotate(new Vector3(0, transform.rotation.x + _speed, 0));
    }
}
