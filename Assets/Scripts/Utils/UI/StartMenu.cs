using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
        public GameObject menuPanel;
        public GameObject buttonMenu;

    public void Awake()
    {
        menuPanel.SetActive(false);
        buttonMenu.SetActive(true);
    }
        public void OpenMenu()
        {
            menuPanel.SetActive(true);
            buttonMenu.SetActive(false);
        }

        public void CloseMenu()
        {
            menuPanel.SetActive(false);
            buttonMenu.SetActive(true);
        }
}

