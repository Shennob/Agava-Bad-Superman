using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTreePlayerSeter : MonoBehaviour
{
    [SerializeField] private BehaviorTree _tree;

    private void Awake()
    {
        var player = FindObjectOfType<PlayerAnimations>().gameObject;
        _tree.SetVariableValue("Target", player);
    }

    public void PlayerSeter(GameObject player)
    {
        _tree.SetVariableValue("Target", player);
    }
}
