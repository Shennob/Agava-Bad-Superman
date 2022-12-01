using BehaviorDesigner.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMan : MonoBehaviour
{
    [SerializeField] private BehaviorTree _walkState;
    [SerializeField] private BehaviorTree _searchState;
    [SerializeField] private BehaviorTree _followState;

    private WantedLevel _wantedLevel;

    private void Awake()
    {
        _wantedLevel = FindObjectOfType<WantedLevel>();

        StateChange();
    }

    private void OnEnable()
    {
        _wantedLevel.IncreaseLevel += OnLevelChanged;
        _wantedLevel.DecreaseLevel += OnLevelChanged;
    }

    private void OnDisable()
    {
        _wantedLevel.IncreaseLevel -= OnLevelChanged;
        _wantedLevel.DecreaseLevel -= OnLevelChanged;
    }

    private void OnLevelChanged(int obj)
    {
        StateChange();
    }

    private void StateChange()
    {
        if (_wantedLevel.CurrentWantedLevel == 1)
        {
            _searchState.enabled = false;
            _walkState.enabled = false;
            _followState.enabled = true;
        }
        else if(_wantedLevel.CurrentWantedLevel >= 2)
        {
            _searchState.enabled = true;
            _walkState.enabled = false;
            _followState.enabled = false;
        }
        else if (_wantedLevel.CurrentWantedLevel == 0)
        {
            _searchState.enabled = false;
            _walkState.enabled = true;
            _followState.enabled = false;
        }
    }
}
