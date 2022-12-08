using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotator : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    private void Update()
    {
       transform.Rotate(new Vector3(transform.rotation.x + _speed, 0, 0));
    }
}
