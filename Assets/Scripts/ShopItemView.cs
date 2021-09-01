using UnityEngine;
using UnityEngine.UI;

namespace Game.Shop
{
    public class ShopItemView : MonoBehaviour
    {
        private ShopItemData _shopItem;

        [SerializeField] private Image _image;
        [SerializeField] private Text _headerText;
        [SerializeField] private Text _descriptionText;

        public void Init(ShopItemData shopItem)
        {
            _shopItem = shopItem;

            _image.sprite = _shopItem.Sprite;
            _headerText.text = _shopItem.Name;
            _descriptionText.text = _shopItem.Description;
        }
    }
}