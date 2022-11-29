using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class SplineSeter : MonoBehaviour
{
    [SerializeField] private SplineFollower _splineFollower;

    private void Awake()
    {
        _splineFollower.spline = FindObjectOfType<SplineComputer>();
    }

    public void StopMovement()
    {
        _splineFollower.follow = false;
    }
}
