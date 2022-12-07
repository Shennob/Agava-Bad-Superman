using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianPeopleTargetSeter : MonoBehaviour
{
    [SerializeField] private BehaviorTree _canSeeTree;

    private void Start()
    {
        var player = FindObjectOfType<PlayerAnimations>().gameObject;

        if (_canSeeTree != null)
        {
            _canSeeTree.SetVariableValue("FoundObject", player);
        }
    }
}
