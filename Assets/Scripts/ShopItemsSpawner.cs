using UnityEngine;
using UnityEngine.Events;

namespace Game.Shop
{
    public class ShopItemsSpawner : MonoBehaviour
    {
        private ShopItemData[] _items;

        [SerializeField] private Transform _rootTransform;
        [SerializeField] private ShopItemView _shopItemPrefab;

        public UnityAction<ShopItemData, Price> ItemBuyClicked;
        public UnityAction<ShopItemData> ItemSelectClicked;

        public void Init(ShopItemData[] items)
        {
            _items = items;



            for (int i = 0; i < _items.Length; i++)
            {
                ShopItemView view = Instantiate(_shopItemPrefab, _rootTransform);
                view.name = $"ShopItem_{_items[i].Name}";
                view.Init(_items[i]);
                view.SelectClicked += () => ItemSelectClicked?.Invoke(_items[i]);
                view.BuyClicked += (price) => ItemBuyClicked?.Invoke(_items[i], price);
            }
        }
    }
}