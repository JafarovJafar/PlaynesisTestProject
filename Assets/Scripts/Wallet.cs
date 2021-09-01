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
        private Dictionary<Currency, float> currencies;

        public UnityAction Updated;

        public void Init()
        {
            // получаем данные из сейва
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

        public float Get(Currency currency, float amount)
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

                    return amount;
                }
            }
            else
            {
                Debug.LogError("ТАКОЙ ВАЛЮТЫ НЕТ В КОШЕЛЬКЕ!!!");
            }

            return 0;
        }
    }
}