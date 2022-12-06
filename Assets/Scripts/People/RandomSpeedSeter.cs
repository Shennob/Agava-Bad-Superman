using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpeedSeter : MonoBehaviour
{
    [SerializeField] private BehaviorTree _walkableSourceTree;

    private void Awake()
    {
        float speed = Random.Range(5, 10);

        _walkableSourceTree.SetVariableValue("Speed", speed);
    }
}
