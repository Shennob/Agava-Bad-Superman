using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WantedStarView : MonoBehaviour
{
    [SerializeField] private Transform _fartherPanel;
    [SerializeField] private GameObject _starTemplate;

    private WantedLevel _wantedLevel;

    private void Awake()
    {
        _wantedLevel = FindObjectOfType<WantedLevel>();
    }

    private void OnEnable()
    {
        _wantedLevel.IncreaseLevel += OnWantedLevelUp;
    }

    private void OnDisable()
    {
        _wantedLevel.IncreaseLevel -= OnWantedLevelUp;
    }

    private void OnWantedLevelUp(int wantedLevel)
    {
        Instantiate(_starTemplate, _fartherPanel);
    }
}
