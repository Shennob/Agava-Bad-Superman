using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    private const string CharacterSaveKey = "Character";

    [SerializeField] private GameObject[] _characters;

    private void Awake()
    {
        int id = PlayerPrefs.GetInt(CharacterSaveKey);
        Instantiate(_characters[id], transform.position, Quaternion.identity);
    }
}
