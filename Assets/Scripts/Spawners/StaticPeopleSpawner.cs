using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPeopleSpawner : MonoBehaviour
{
    public void Spawn(GameObject people, Animator animator)
    {
        animator.SetBool("IsDie", false);
        StartCoroutine(EnableWithDelay(people));
    }

    private IEnumerator EnableWithDelay(GameObject people)
    {
        yield return new WaitForSeconds(3f);
        people.SetActive(true);
    }
}
