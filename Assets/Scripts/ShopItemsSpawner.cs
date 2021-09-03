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
                ShopItemData item = _items[i];

                ShopItemView view = Instantiate(_shopItemPrefab, _rootTransform);
                view.name = $"ShopItem_{item.Name}";
                view.Init(item);
                view.SelectClicked += () => ItemSelectClicked?.Invoke(item);
                view.BuyClicked += (price) => ItemBuyClicked?.Invoke(item, price);
                view.Finished += () => item.SetBought(false);

                item.Updated += () =>
                {
                    view.Refresh();
                };
            }
        }
    }
}