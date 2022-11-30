using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Store _characterPreview;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _equipButton;

    private void OnEnable()
    {
        _characterPreview.CharacterChange += OnCharacterChanged;
    }

    private void OnDisable()
    {
        _characterPreview.CharacterChange -= OnCharacterChanged;
    }

    private void OnCharacterChanged(CharacterInfo characterInfo, bool canBuy)
    {
        Render(characterInfo, canBuy);
    }

    private void Render(CharacterInfo characterInfo, bool canBuy)
    {
        _nameText.text = characterInfo.Name;
        _buyButton.gameObject.SetActive(false);
        _equipButton.gameObject.SetActive(false);

        if (characterInfo.IsBuyed == false)
        {
            _buyButton.gameObject.SetActive(true);
            _buyButton.interactable = canBuy;
            _priceText.text = characterInfo.Price.ToString();
        }
        else
        {
            _equipButton.gameObject.SetActive(true);
        }
    }
}
