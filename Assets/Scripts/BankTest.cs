#region

using Bank;
using UnityEngine;

#endregion

public class BanTest : MonoBehaviour
{
    [SerializeField] private Transform _uiContainer;
    [SerializeField] private Transform _uiPosition;
    [SerializeField] private BankUI _bankUIPrefab;

    private Bank.Bank _bank;

    private const KeyCode AddCoinsKeyCode = KeyCode.Alpha1;
    private const KeyCode AddDollarsKeyCode = KeyCode.Alpha2;
    private const KeyCode AddEnergyKeyCode = KeyCode.Alpha3;

    private void Awake()
    {
        _bank = new Bank.Bank();

        InitializeUI();
    }

    private void InitializeUI()
    {
        BankUI bankUI = Instantiate(_bankUIPrefab, _uiPosition.position, Quaternion.identity, _uiContainer);
        bankUI.Initialize(_bank);
    }

    private void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKeyDown(AddCoinsKeyCode))
            _bank.AddCurrency(CurrencyType.Coins, 1);

        if (Input.GetKeyDown(AddDollarsKeyCode))
            _bank.AddCurrency(CurrencyType.Dollars, 1);

        if (Input.GetKeyDown(AddEnergyKeyCode))
            _bank.AddCurrency(CurrencyType.Energy, 1);
    }
}