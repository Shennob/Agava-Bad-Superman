using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLoock : MonoBehaviour
{
    [SerializeField] private float _lookSensitivity = 50f;
    [SerializeField] private float _xAxisClampMax = 5f;
    [SerializeField] private float _yAxisClampMax = 5f;
    [SerializeField] private float _yAxisClampMin = -1f;

    private float _xRotation;
    private float _yRotation;

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * _lookSensitivity * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * _lookSensitivity * Time.deltaTime;

        _yRotation -= mouseY;
        _xRotation -= -mouseX;
        _yRotation = Mathf.Clamp(_yRotation, -_yAxisClampMax, _yAxisClampMin);
        _xRotation = Mathf.Clamp(_xRotation, -_xAxisClampMax, _xAxisClampMax);

        transform.localRotation = Quaternion.Euler(_yRotation, _xRotation, 0);
    }
}
