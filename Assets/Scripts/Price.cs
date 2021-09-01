using System;
using UnityEngine;

namespace Game.Shop
{
    [Serializable]
    public class Price
    {
        [SerializeField] private Currency _currency;
        [SerializeField] private float _amount;

        public Currency Currency => _currency;
        public float Amount => _amount;

        public Price(Currency currency, float amount)
        {
            _currency = currency;
            _amount = amount;
        }
    }
}