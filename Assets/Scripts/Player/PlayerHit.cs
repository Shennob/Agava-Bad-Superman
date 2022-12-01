using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private const string Punch = "IsPunch";

    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Hit();
        }

    }

    private void Hit()
    {
        _animator.SetBool(Punch, true);
        StartCoroutine(DissableWithDelay());
    }

    private IEnumerator DissableWithDelay()
    {
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length);
        _animator.SetBool(Punch, false);
    }
}
