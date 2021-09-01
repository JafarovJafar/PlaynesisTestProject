using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Shop
{
    [CreateAssetMenu(fileName = "NewShopItem", menuName = "Custom Assets/ShopItemData")]
    public class ShopItemData : ScriptableObject
    {
        #region Properties
        public string Name => _name;
        public string Description => _description;
        public Price[] Prices => _prices;
        public Sprite Sprite => _sprite;
        #endregion

        [SerializeField] private string _name;
        [SerializeField] private string _description;

        [SerializeField] private Price[] _prices;
        [SerializeField] private Sprite _sprite;
    }
}