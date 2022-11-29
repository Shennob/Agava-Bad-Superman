using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _price;

    public string Name => _name;
    public int Price => _price;
}
