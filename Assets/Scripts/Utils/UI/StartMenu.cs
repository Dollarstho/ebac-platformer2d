using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
            Time.timeScale = 0f;
        }

        public void CloseMenu()
        {
            menuPanel.SetActive(false);
            buttonMenu.SetActive(true);
            Time.timeScale = 1f;
        }
}

