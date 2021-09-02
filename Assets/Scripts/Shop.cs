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

        private void Start()
        {
            _inventory.Init();
            _spawner.Init(_inventory.Items);
        }

        private void Update()
        {
            //Debug.Log(TimeFormatter.DateToText(DateTime.Now));
        }
    }
}