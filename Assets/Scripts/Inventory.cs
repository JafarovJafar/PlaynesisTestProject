using UnityEngine;
using Game.Shop;

namespace Game.Common
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] public ShopItemData[] _items;
        public ShopItemData[] Items => _items;

        public void Init()
        {
            // загрузка из сейва

            string some = JsonUtility.ToJson(_items);

            Debug.Log(some);
        }

        public void Add(ShopItemData item)
        {

        }
    }
}