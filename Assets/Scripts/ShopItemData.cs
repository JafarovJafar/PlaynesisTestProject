using UnityEngine;

namespace Game.Shop
{
    [CreateAssetMenu(fileName = "NewShopItem", menuName = "Custom Assets/ShopItemData")]
    public class ShopItemData : ScriptableObject // наверное стоит назвать по другому, потому что будет использоваться не только в магазине. соответственно неймспейс другой
    {
        #region Properties
        public string Name => _name;
        public string Description => _description;
        public Price[] Prices => _prices;
        public Sprite Sprite => _sprite;
        public bool IsAvailable => _isAvailable; // решил, что лучше назвать так, а не IsBought (куплен)
        #endregion

        [SerializeField] private string _name;
        [SerializeField] private string _description;

        [SerializeField] private Price[] _prices;
        [SerializeField] private Sprite _sprite;

        [SerializeField] private bool _isAvailable;
    }
}