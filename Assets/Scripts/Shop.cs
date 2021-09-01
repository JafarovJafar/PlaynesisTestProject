using UnityEngine;

namespace Game.Shop
{
    /// <summary>
    /// Класс магазина
    /// </summary>
    public class Shop : MonoBehaviour
    {
        // по сути это Entry Point магазина

        [SerializeField] private ShopItemsSpawner _spawner;

        private void Start()
        {
            //_spawner.Init(null);


        }
    }
}