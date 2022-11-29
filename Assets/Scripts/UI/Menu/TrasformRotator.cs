using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrasformRotator : MonoBehaviour
{
    private float _turnY;
    private float _speed = 15f;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _turnY = Input.GetAxis("Mouse X");
            transform.Rotate(new Vector3(0, _turnY * _speed, 0));
        }
    }
}
