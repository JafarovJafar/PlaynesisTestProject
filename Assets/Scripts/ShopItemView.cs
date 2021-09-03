using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Game.Common;

namespace Game.Shop
{
    public class ShopItemView : MonoBehaviour
    {
        private ShopItemData _shopItem;

        [SerializeField] private Image _image;
        [SerializeField] private Text _headerText;
        [SerializeField] private Text _descriptionText;
        [SerializeField] private TimerView _timer;

        [SerializeField] private Button _selectButton;

        [SerializeField] private PriceButton _priceButtonPrefab;
        [SerializeField] private Transform _priceButtonsContainer;

        public UnityAction<Price> BuyClicked;
        public UnityAction SelectClicked;
        public UnityAction Finished;

        public void Init(ShopItemData shopItem)
        {
            _shopItem = shopItem;

            _image.sprite = _shopItem.Sprite;
            _headerText.text = _shopItem.Name;
            _descriptionText.text = _shopItem.Description;

            if (_shopItem.Duration <= 0)
            {
                _timer.gameObject.SetActive(false);
            }
            else if (_shopItem.IsBought)
            {
                _timer.Init(_shopItem.EndTime);
                _timer.Finished += () =>
                {
                    _timer.gameObject.SetActive(false);
                    _selectButton.interactable = false;
                };
            }

            if (_shopItem.IsBought)
            {
                _selectButton.onClick.AddListener(() => SelectClicked?.Invoke());
            }
            else
            {
                _selectButton.interactable = false;

                InitPriceButtons(_shopItem);
            }
        }


        public void Refresh()
        {
            if (_shopItem.Duration <= 0)
            {
                _timer.gameObject.SetActive(false);
            }
            else if (_shopItem.IsBought)
            {
                _timer.gameObject.SetActive(true);
                _timer.Init(_shopItem.EndTime);
                _timer.Finished += () =>
                {
                    _timer.gameObject.SetActive(false);
                    _selectButton.interactable = false; // кажется тут этого не должно быть)))
                    InitPriceButtons(_shopItem);
                    Finished?.Invoke();
                };
            }

            if (_shopItem.IsBought)
            {
                _selectButton.onClick.RemoveAllListeners();

                _selectButton.interactable = true;
                _selectButton.onClick.AddListener(() => SelectClicked?.Invoke());

                RemovePriceButtons();
            }
            else
            {
                _selectButton.interactable = false;
            }
        }

        private void InitPriceButtons(ShopItemData data)
        {
            Price[] prices = _shopItem.Prices;

            for (int i = 0; i < _shopItem.Prices.Length; i++)
            {
                PriceButton priceButton = Instantiate(_priceButtonPrefab, _priceButtonsContainer);
                priceButton.Init(prices[i]);
                priceButton.Clicked += (Price) => BuyClicked?.Invoke(Price);
                priceButton.name = $"PriceButton_{prices[i].Currency.Name}";
            }
        }

        private void RemovePriceButtons()
        {
            foreach (Transform child in _priceButtonsContainer)
            {
                Destroy(child.gameObject);
            }
        }
    }
}