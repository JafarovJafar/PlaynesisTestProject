using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Game.Shop;

// тут нет неймспейса, так как эта кнопка может использоваться и в других менюшках, а не только в магазине
public class PriceButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _icon;
    [SerializeField] private Text _amountText;

    public void Init(Price price, UnityAction<Price> Clicked)
    {
        _icon.sprite = price.Currency.Sprite;
        _amountText.text = price.Amount.ToString();

        _button.onClick.AddListener(() => Clicked(price));
    }
}