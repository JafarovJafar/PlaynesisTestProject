using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// возможно тут нужен другой неймспейс
namespace Game.Shop
{
    public class PriceButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _icon;
        [SerializeField] private Text _amountText;

        public Price Price => _price;
        private Price _price;
        
        public UnityAction<Price> Clicked;

        public void Init(Price price)
        {
            _price = price;

            _icon.sprite = _price.Currency.Sprite;
            _amountText.text = _price.Amount.ToString();

            _button.onClick.AddListener(() => Clicked?.Invoke(_price));
        }
    }
}