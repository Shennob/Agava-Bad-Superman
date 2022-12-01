using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotator : MonoBehaviour
{
    private void Update()
    {
       transform.Rotate(new Vector3(transform.rotation.x + 4f, 0, 0));
    }
}
