using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleStateSeter : MonoBehaviour
{
    [SerializeField] private BehaviorTree _walkState;
    [SerializeField] private BehaviorTree _runAwayState;

    private WantedLevel _wantedLevel;

    private void Awake()
    {
        _wantedLevel = FindObjectOfType<WantedLevel>();

        StateChange();
    }

    private void OnEnable()
    {
        _wantedLevel.LevelChange += OnLevelChanged;
    }

    private void OnDisable()
    {
        _wantedLevel.LevelChange -= OnLevelChanged;
    }

    private void OnLevelChanged(int obj)
    {
        StateChange();
    }

    private void StateChange()
    {
        if (_wantedLevel.CurrentWantedLevel > 0)
        {
            _runAwayState.enabled = true;
            _walkState.enabled = false;
        }
        else
        {
            _runAwayState.enabled = false;
            _walkState.enabled = true;
        }
    }
}
