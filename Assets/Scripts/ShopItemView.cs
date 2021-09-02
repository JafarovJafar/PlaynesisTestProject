﻿using UnityEngine;
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

        [SerializeField] private Button _selectButton;

        [SerializeField] private PriceButton _priceButtonPrefab;
        [SerializeField] private Transform _priceButtonsContainer;

        public UnityAction<Price> BuyClicked;
        public UnityAction SelectClicked;

        public void Init(ShopItemData shopItem)
        {
            _shopItem = shopItem;

            _image.sprite = _shopItem.Sprite;
            _headerText.text = _shopItem.Name;
            _descriptionText.text = _shopItem.Description;

            //_timerText.text = TimerFormatter.DateToTime(_shopItem.);

            if (_shopItem.IsAvailable)
            {
                _selectButton.onClick.AddListener(() => SelectClicked?.Invoke());
            }
            else
            {
                _selectButton.interactable = false;
            }

            Price[] prices = _shopItem.Prices;

            for (int i = 0; i < _shopItem.Prices.Length; i++)
            {
                PriceButton priceButton = Instantiate(_priceButtonPrefab, _priceButtonsContainer);
                priceButton.Init(prices[i], BuyClicked);
                priceButton.name = $"PriceButton_{prices[i].Currency.Name}";
            }
        }
    }
}