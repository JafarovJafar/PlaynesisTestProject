using UnityEngine;
using Game.Shop;

namespace Game.Common
{
    public class Inventory : MonoBehaviour
    {
        public ShopItemData[] _items;
        public ShopItemData[] Items => _items;

        public void Init()
        {
            // загрузка из сейва
        }

        public void Add(ShopItemData item)
        {

        }
    }
}