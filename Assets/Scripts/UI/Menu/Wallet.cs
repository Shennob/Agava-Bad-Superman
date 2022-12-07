using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    private const string CoinsSaveKey = "Coins";

    [SerializeField] private TMP_Text _coinText;

    private int _coins;

    public event UnityAction CoinsChange;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(CoinsSaveKey))
        {
            _coins = PlayerPrefs.GetInt(CoinsSaveKey);
        }
        else
        {
            _coins = 0;
        }

        _coinText = FindObjectOfType<MoneyView>().GetComponent<TMP_Text>();
    }

    private void Start()
    {
        _coinText.text = _coins.ToString();
    }

    public void AddCoins(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException("Value can't be negative");
        }

        _coins += value;
        _coinText.text = _coins.ToString();
        CoinsChange?.Invoke();
        PlayerPrefs.SetInt(CoinsSaveKey, _coins);
    }

    public bool CanDecreaseCoins(int value)
    {
        return _coins >= value;
    }

    public void DecreaseCoins(int value)
    {
        if (CanDecreaseCoins(value))
        {
            _coins -= value;
            _coinText.text = _coins.ToString();
            CoinsChange?.Invoke();
            PlayerPrefs.SetInt(CoinsSaveKey, _coins);
        }
    }
}
