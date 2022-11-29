using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private CharacterPreview _characterPreview;

    private void OnEnable()
    {
        _characterPreview.CharacterChange += OnCharacterChanged;
    }

    private void OnDisable()
    {
        _characterPreview.CharacterChange -= OnCharacterChanged;
    }

    private void OnCharacterChanged(string name)
    {
        _nameText.text = name.ToString();
    }
}
