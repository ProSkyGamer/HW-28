#region

using System;
using System.Collections.Generic;
using Bank;
using UnityEngine;

#endregion

[CreateAssetMenu]
public class CurrencySpritesSO : ScriptableObject
{
    public List<CurrencySprite> CurrencySprites;
    public Sprite DefaultCurrencySprite;

    public Sprite GetCurrencySpriteFor(CurrencyType type)
    {
        Sprite foundSprite = CurrencySprites.Find(s => s.Type == type).Sprite;

        if (foundSprite == null)
            foundSprite = DefaultCurrencySprite;

        return foundSprite;
    }
}

[Serializable]
public class CurrencySprite
{
    public CurrencyType Type;
    public Sprite Sprite;
}