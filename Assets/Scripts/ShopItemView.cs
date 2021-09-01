using UnityEngine;

namespace Game.Shop
{
    public class ShopItemView : MonoBehaviour
    {
        private ShopItemData _shopItem;


        public void Init(ShopItemData shopItem)
        {
            _shopItem = shopItem;
        }
    }
}