using BehaviorDesigner.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMan : MonoBehaviour
{
    [SerializeField] private BehaviorTree _walkState;
    [SerializeField] private BehaviorTree _searchState;

    private WantedLevel _wantedLevel;

    private void Awake()
    {
        _wantedLevel = FindObjectOfType<WantedLevel>();

        StateChange();
    }

    private void OnEnable()
    {
        _wantedLevel.IncreaseLevel += OnLevelChanged;
    }

    private void OnDisable()
    {
        _wantedLevel.IncreaseLevel -= OnLevelChanged;
    }

    private void OnLevelChanged(int obj)
    {
        StateChange();
    }

    private void StateChange()
    {
        if (_wantedLevel.CurrentWantedLevel > 0)
        {
            _searchState.enabled = true;
            _walkState.enabled = false;
        }
        else
        {
            _searchState.enabled = false;
            _walkState.enabled = true;
        }
    }
}
