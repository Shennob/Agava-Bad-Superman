using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrasformRotator : MonoBehaviour
{
    [SerializeField] private CameraLoock _cameraLoock;
    private float _turnY;
    private float _speed = 15f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _cameraLoock.enabled = false;
        }

        if (Input.GetMouseButton(0))
        {
            _turnY = Input.GetAxis("Mouse X");
            transform.Rotate(new Vector3(0, _turnY * _speed, 0));
        }

        if (Input.GetMouseButtonUp(0))
        {
            _cameraLoock.enabled = true;
        }
    }
}
