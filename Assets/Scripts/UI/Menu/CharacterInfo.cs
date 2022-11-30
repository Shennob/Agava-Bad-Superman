using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] private string _saveKey;
    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private bool _isBuyed = false;

    private int _buyedValue;

    public string Name => _name;
    public int Price => _price;
    public bool IsBuyed => _isBuyed;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(_saveKey))
        {
            _buyedValue = PlayerPrefs.GetInt(_saveKey);
        }
        else
        {
            if (_isBuyed)
            {
                _buyedValue = 1;
            }
            else
            {
                _buyedValue = 0;
            }
        }

        ChangeBuyedFlag();
    }

    public void Buy()
    {
        _buyedValue = 1;
        ChangeBuyedFlag();
        PlayerPrefs.SetInt(_saveKey, _buyedValue);
    }

    private void ChangeBuyedFlag()
    {
        if (_buyedValue == 0)
        {
            _isBuyed = false;
        }
        else
        {
            _isBuyed = true;
        }
    }
}
