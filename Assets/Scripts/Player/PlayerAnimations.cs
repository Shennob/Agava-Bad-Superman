using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private const string Jump = "IsJump";

    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetBool(Jump, true);
        }
    }

    public void MoveAnimation()
    {
        _animator.SetBool("IsMove", true);
        Debug.Log(1);
    }

    public void EndJumpAnimation()
    {
        _animator.SetBool(Jump, false);
    }

    public void StartJumpAnimation()
    {
        _animator.SetBool(Jump, true);
    }
}
