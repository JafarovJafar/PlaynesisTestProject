using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Shop
{
    [CreateAssetMenu(fileName = "NewShopItem", menuName = "Custom Assets/ShopItemData")]
    [Serializable]
    public class ShopItemData : ScriptableObject // наверное стоит назвать по другому, потому что будет использоваться не только в магазине. соответственно неймспейс другой
    {
        #region Properties
        public string Name => _name;
        public string Description => _description;
        public Price[] Prices => _prices;
        public Sprite Sprite => _sprite;
        public bool IsBought => _isBought; // решил, что лучше назвать так, а не IsBought (куплен)
        public DateTime StartTime => _startTime;
        public float Duration => _duration; // в минутах
        public DateTime EndTime => _startTime + TimeSpan.FromMinutes(_duration);
        #endregion

        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private Price[] _prices;
        [SerializeField] private Sprite _sprite;

        [SerializeField] private bool _isBought;

        [SerializeField] private DateTime _startTime;
        [SerializeField] private float _duration;

        public UnityAction Updated;

        public void SetStartTime(DateTime dateTime)
        {
            _startTime = dateTime;

            Updated?.Invoke();
        }

        public void SetBought(bool value)
        {
            _startTime = DateTime.Now;
            _isBought = value;

            Updated?.Invoke();
        }
    }
}