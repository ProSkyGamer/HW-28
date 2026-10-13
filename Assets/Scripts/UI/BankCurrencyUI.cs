#region

using TMPro;
using UnityEngine;
using UnityEngine.UI;

#endregion

public class BankCurrencyUI : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _text;

    public void Initialize(Sprite currencySprite, int currencyAmount)
    {
        _image.sprite = currencySprite;
        SetCurrencyAmount(currencyAmount);
    }

    public void UpdateAmount(int amount)
    {
        SetCurrencyAmount(amount);
    }

    private void SetCurrencyAmount(int amount)
    {
        _text.text = amount.ToString();
    }
}