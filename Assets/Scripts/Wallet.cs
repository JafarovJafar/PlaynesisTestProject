using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Shop
{
    /// <summary>
    /// Класс кошелька. Тут хранятся все валюты.
    /// </summary>
    public class Wallet : MonoBehaviour
    {
        private Dictionary<Currency, float> currencies = new Dictionary<Currency, float>();

        public UnityAction Updated;

        [SerializeField] private Currency currency;

        public void Init()
        {
            // получаем данные из сейва фейково

            currencies.Add(currency, 1000);
        }

        public void Add(Currency currency, float amount)
        {
            if (currencies.ContainsKey(currency))
            {
                currencies[currency] += amount;
            }
            else
            {
                currencies.Add(currency, amount);
            }

            Updated?.Invoke();
        }

        public void Remove(Currency currency, float amount, UnityAction<bool> Success)
        {
            if (currencies.ContainsKey(currency))
            {
                if (currencies[currency] < amount)
                {
                    Debug.LogError("НЕДОСТАТОЧНО СРЕДСТВ!!!");
                }
                else
                {
                    currencies[currency] -= amount;

                    Updated?.Invoke();

                    Success?.Invoke(true);
                }
            }
            else
            {
                Debug.LogError("ТАКОЙ ВАЛЮТЫ НЕТ В КОШЕЛЬКЕ!!!");
            }

            Success?.Invoke(false);
        }
    }
}