#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Bank
{
    public class Bank
    {
        public event Action<CurrencyType> CurrencyValueChanged;

        private readonly Dictionary<CurrencyType, int> _storedCurrency = new();

        public void AddCurrency(CurrencyType type, int amount)
        {
            if (_storedCurrency.TryAdd(type, amount) == false)
                _storedCurrency[type] += amount;

            CurrencyValueChanged?.Invoke(type);
        }

        public bool TrySpendCurrency(CurrencyType type, int amount)
        {
            if (_storedCurrency.TryGetValue(type, out int storedAmount))
                if (storedAmount >= amount)
                {
                    _storedCurrency[type] -= amount;

                    CurrencyValueChanged?.Invoke(type);

                    return true;
                }

            return false;
        }

        public int GetCurrency(CurrencyType type)
        {
            return _storedCurrency.GetValueOrDefault(type, 0);
        }

        public List<CurrencyType> GetAllStoredCurrencyTypes()
        {
            return _storedCurrency.Keys.ToList();
        }
    }
}