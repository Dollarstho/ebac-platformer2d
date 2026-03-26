using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;
using System.ComponentModel;

public class UIInGameManager : Singleton<UIInGameManager>
{
    public TextMeshProUGUI uiTextCoins;
    public TextMeshProUGUI uiTextLife;

    public static void UpdateTextCoins(string s)
    { 
        Instance.uiTextCoins.text = s; 
    }

    public static void UpdateTextLife(string s)
    {
        Instance.uiTextLife.text = s;
    }

}
