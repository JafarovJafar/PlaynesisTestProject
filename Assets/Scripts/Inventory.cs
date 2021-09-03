using System;
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
            ImitateSave(); return;

            // загрузка из сейва
            _items = JsonHelper.FromJson<ShopItemData>(SaveManager.Load());

            foreach(ShopItemData item in _items)
            {
                if (item.Duration > 0)
                {
                    Debug.Log(item.StartTime);
                }
            }
        }

        public void Add(ShopItemData item)
        {
            ShopItemData[] newItems = new ShopItemData[_items.Length + 1];
            
            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }

            newItems[newItems.Length - 1] = item;

            _items = newItems;

            Save();
        }

        private void ImitateSave()
        {
            foreach(ShopItemData item in _items)
            {
                item.SetStartTime(DateTime.Now);
            }

            string some = JsonHelper.ToJson(_items);

            SaveManager.Save(some);

            ShopItemData[] datas = JsonHelper.FromJson<ShopItemData>(some);
        }

        private void Save()
        {
            SaveManager.Save(JsonHelper.ToJson(_items));
        }
    }
}