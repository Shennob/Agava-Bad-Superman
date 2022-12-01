using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private const string Punch = "IsPunch";

    [SerializeField] private Animator _animator;
    [SerializeField] private CapsuleCollider[] _enabledColliders;

    private WantedLevel _wantedLevel;

    private void Awake()
    {
        _wantedLevel = FindObjectOfType<WantedLevel>();

        foreach (var collider in _enabledColliders)
        {
            collider.enabled = false;
        }
    }

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

        foreach(var collider in _enabledColliders)
        {
            collider.enabled = true;
        }

        StartCoroutine(DissableWithDelay());
    }

    private IEnumerator DissableWithDelay()
    {
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length);

        foreach (var collider in _enabledColliders)
        {
            collider.enabled = false;
        }

        _animator.SetBool(Punch, false);
    }
}
