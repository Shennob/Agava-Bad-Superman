using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTreePlayerSeter : MonoBehaviour
{
    [SerializeField] private BehaviorTree _canSeeTree;

    private void Awake()
    {
        var player = FindObjectOfType<PlayerAnimations>().gameObject;

        if(_canSeeTree != null)
        {
            _canSeeTree.SetVariableValue("FoundObject", player);
        }
    }

    public void PlayerSeter(GameObject player)
    {
    }
}
