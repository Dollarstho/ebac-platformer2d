using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;
using System;

public class ItemManager : Singleton<ItemManager>
{

    public SOCoinCollect coinCollect;
    public SOLifeCollect lifeCollect;

    public TextMeshProUGUI Coins;
    public TextMeshProUGUI Life;

    private void Start()
    {
        Reset();
    }
    

    public void Reset()
    {
      coinCollect.coinValue = 0;
      lifeCollect.lifeValue = 1;
    }

    public void AddCoins(int amount = 1)
    {
        coinCollect.coinValue += amount;
        UpdateUI();
    }
    public void AddLife(int amount = 1)
    {
        lifeCollect.lifeValue += amount;
        UpdateUI();
    }

    public void UpdateUI()
    {
        UIInGameManager.UpdateTextCoins(coinCollect.coinValue.ToString());
        UIInGameManager.UpdateTextLife(lifeCollect.lifeValue.ToString());
    }
}
