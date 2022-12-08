using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class SplineSeter : MonoBehaviour
{
    [SerializeField] private SplineFollower _splineFollower;
    [SerializeField] private SplineComputer _spline;

    //private void Awake()
    //{
    //    _splineFollower.spline = FindObjectOfType<SplineComputer>();
    //}

    public void SetSpline(SplineFollower splineFollower)
    {
        splineFollower.spline = _spline;
    }

    public void StopMovement()
    {
        _splineFollower.follow = false;
    }
}
