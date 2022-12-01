using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTreePlayerSeter : MonoBehaviour
{
    [SerializeField] private BehaviorTree _followTree;

    private void Awake()
    {
        var player = FindObjectOfType<PlayerAnimations>().gameObject;

        if(_followTree != null)
        {
            _followTree.SetVariableValue("Target", player);
        }
    }

    public void PlayerSeter(GameObject player)
    {
    }
}
