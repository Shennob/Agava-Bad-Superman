using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WadOfMoney : MonoBehaviour
{
    [SerializeField] private int _countOfGiveMoney;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.TryGetComponent(out Wallet wallet))
        {
            wallet.AddCoins(_countOfGiveMoney);
            Destroy(gameObject);
        }
    }
}
