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
        #endregion

        [SerializeField] private string _name;
        [SerializeField] private string _description;

        [SerializeField] private Price[] _prices;
    }
}