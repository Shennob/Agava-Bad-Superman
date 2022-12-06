using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _currentValue;
    [SerializeField] private TMP_Text _maxValue;

    private void Awake()
    {
        _slider.value = _slider.maxValue;
    }

    protected void OnValueChanged(float currentValue, float maxValue)
    {
        _currentValue.text = ((int)currentValue).ToString();
        _maxValue.text = maxValue.ToString();
        _slider.value = currentValue / maxValue;
    }
}
