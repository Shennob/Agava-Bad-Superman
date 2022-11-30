using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Store : MonoBehaviour
{
    private const string CharacterSaveKey = "Character";

    [SerializeField] private CharacterInfo[] _characters;
    [SerializeField] private Wallet _wallet;

    private int _currentCharacter;
    private int _previousCharacter;

    public event UnityAction<CharacterInfo, bool> CharacterChange;

    private void OnEnable()
    {
        _wallet.CoinsChange += OnCoinsChanged;
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey(CharacterSaveKey))
        {
            _currentCharacter = PlayerPrefs.GetInt(CharacterSaveKey);
        }
        else
        {
            _currentCharacter = 0;
        }
        
    }

    private void Start()
    {
        _previousCharacter = _currentCharacter;

        for (int i = 0; i < _characters.Length; i++)
        {
            _characters[i].gameObject.SetActive(false);
        }

        ShowCharacter(_currentCharacter);
    }

    private void OnDisable()
    {
        _wallet.CoinsChange += OnCoinsChanged;
    }

    public void SelectCharacter()
    {
        PlayerPrefs.SetInt(CharacterSaveKey, _currentCharacter);
    }

    public void BuyCharacter()
    {
        _wallet.DecreaseCoins(_characters[_currentCharacter].Price);
        _characters[_currentCharacter].Buy();
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

    private void OnCoinsChanged()
    {
        ShowCharacter(_currentCharacter);
    }

    private void ShowCharacter(int index)
    {
        _characters[_previousCharacter].gameObject.SetActive(false);
        _currentCharacter = index;
        _previousCharacter = _currentCharacter;
        _characters[index].gameObject.SetActive(true);
        CharacterChange?.Invoke(_characters[index], _wallet.CanDecreaseCoins(_characters[index].Price));
    }
}
