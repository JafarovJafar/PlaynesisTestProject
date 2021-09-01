using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Shop
{
    public class ShopItemView : MonoBehaviour
    {
        private ShopItemData _shopItem;

        [SerializeField] private Image _image;
        [SerializeField] private Text _headerText;
        [SerializeField] private Text _descriptionText;
        [SerializeField] private Text _timerText;

        [SerializeField] private PriceButton _priceButtonPrefab;

        [SerializeField] private Transform _priceButtonsContainer;

        private UnityAction<Price> BuyClicked;

        public void Init(ShopItemData shopItem)
        {
            _shopItem = shopItem;

            _image.sprite = _shopItem.Sprite;
            _headerText.text = _shopItem.Name;
            _descriptionText.text = _shopItem.Description;

            // ТАЙМЕР ЕСЛИ НУЖНО

            foreach (Price price in _shopItem.Prices)
            {
                PriceButton priceButton = Instantiate(_priceButtonPrefab, _priceButtonsContainer);
                priceButton.Init(price, BuyClicked);
            }
        }
    }
}