using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterPreview : MonoBehaviour
{
    [SerializeField] private CharacterInfo[] _characters;

    private int _currentCharacter = 0;
    private int _previousCharacter;

    public event UnityAction<CharacterInfo> CharacterChange;

    private void Start()
    {
        _previousCharacter = _currentCharacter;
        ShowCharacter(_currentCharacter);
    }

    public void NextCharacter()
    {
        _currentCharacter++;

        if (_currentCharacter > _characters.Length - 1)
        {
            ShowCharacter(0);
        }
        else
        {
            ShowCharacter(_currentCharacter);
        }
    }

    public void PreviousCharacter()
    {
        _currentCharacter--;

        if (_currentCharacter < 0)
        {
            ShowCharacter(_characters.Length - 1);
        }
        else
        {
            ShowCharacter(_currentCharacter);
        }
    }

    private void ShowCharacter(int index)
    {
        _characters[_previousCharacter].gameObject.SetActive(false);
        _currentCharacter = index;
        _previousCharacter = _currentCharacter;
        _characters[index].gameObject.SetActive(true);
        CharacterChange?.Invoke(_characters[index]);
    }
}
