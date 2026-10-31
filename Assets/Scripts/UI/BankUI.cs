#region

using System;
using System.Collections.Generic;
using Bank;
using UnityEngine;

#endregion

public class BankUI : MonoBehaviour
{
    [SerializeField] private Transform _allCurrenciesContainer;
    [SerializeField] private BankCurrencyUI _currencyUIPrefab;

    [SerializeField] private CurrencySpritesSO _currencySpritesSO;

    private readonly Dictionary<CurrencyType, BankCurrencyUI> _allCreatedCurrencyUIs = new();

    private Bank.Bank _bank;

    public void Initialize(Bank.Bank bank)
    {
        _bank = bank;

        bank.CurrencyValueChanged += Bank_OnCurrencyValueChanged;

        UpdateAllCurrenciesFor(_bank);
    }

    private void Bank_OnCurrencyValueChanged(CurrencyType updatedCurrencyType)
    {
        UpdateCurrency(updatedCurrencyType, _bank.GetCurrency(updatedCurrencyType));
    }

    private void UpdateAllCurrenciesFor(Bank.Bank bank)
    {
        foreach (CurrencyType currencyType in bank.GetAllStoredCurrencyTypes())
        {
            UpdateCurrency(currencyType, bank.GetCurrency(currencyType));
        }
    }

    private void UpdateCurrency(CurrencyType currencyType, int currencyAmount)
    {
        if (_allCreatedCurrencyUIs.TryGetValue(currencyType, out BankCurrencyUI currencyUI))
            currencyUI.UpdateAmount(currencyAmount);
        else
            AddCurrencyUI(currencyType, currencyAmount);
    }

    private void AddCurrencyUI(CurrencyType currencyType, int startingAmount)
    {
        BankCurrencyUI createdCurrencyUI = Instantiate(_currencyUIPrefab, _allCurrenciesContainer);
        createdCurrencyUI.Initialize(_currencySpritesSO.GetCurrencySpriteFor(currencyType), startingAmount);

        _allCreatedCurrencyUIs.Add(currencyType, createdCurrencyUI);
    }

    private void OnDestroy()
    {
        _bank.CurrencyValueChanged -= Bank_OnCurrencyValueChanged;
    }
}