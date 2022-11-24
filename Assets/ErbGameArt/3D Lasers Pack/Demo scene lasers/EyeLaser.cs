using System.Collections.Generic;
using UnityEngine;

public class EyeLaser : MonoBehaviour
{
    [SerializeField] private List<EGA_Laser> _firePoints; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (var firePoint in _firePoints)
            {
                firePoint.gameObject.SetActive(true);
            }                                       
        }

        if (Input.GetMouseButtonUp(0))
        {
            foreach (var firePoint in _firePoints)
            {
                firePoint.gameObject.SetActive(false);
            }                   
        }       
    }   
}
