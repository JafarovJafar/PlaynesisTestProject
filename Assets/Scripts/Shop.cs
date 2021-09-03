using UnityEngine;
using Game.Common;

namespace Game.Shop
{
    /// <summary>
    /// Класс магазина
    /// </summary>
    public class Shop : MonoBehaviour
    {
        // по сути это Entry Point магазина

        [SerializeField] private Inventory _inventory;
        [SerializeField] private ShopItemsSpawner _spawner;
        [SerializeField] private Wallet _wallet;

        private void Start()
        {
            _inventory.Init();
            _wallet.Init();

            _spawner.Init(_inventory.Items);
            _spawner.ItemBuyClicked += ProcessItemBuy;
        }

        private void ProcessItemBuy(ShopItemData item, Price price)
        {
            _wallet.Remove(price.Currency, price.Amount, (Success) =>
            {
                if (Success)
                {
                    _inventory.Add(item);
                    item.SetBought(true);
                }
            });
        }
    }
}