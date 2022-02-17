using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text[] scoreTxts;

    [SerializeField] private Text characterLifesTxt;

    [SerializeField] private GameObject menuButton;

    [SerializeField] private List<GameObject> panels = new List<GameObject>();

    private GameObject activePanel;

    //изменение текста со счетом игры
    public void ChangeScoreText(int value)
    {
        foreach (var item in scoreTxts)
        {
            item.text = "СЧЕТ: " + value.ToString();
        }
    }

    //выбор активной панели в UI : 0 - панель меню, 1- панель победы, 2 - панель поражения
    public void SelectActivePanel(int index)
    {
        scoreTxts[0].enabled = false;

        menuButton.SetActive(false);

        panels[index].SetActive(true);

        activePanel = panels[index];

        if (index == 2) return;

        Time.timeScale = 0; 
    }

    //выключает активную панели и возобновляет игру
    public void DisableActivePanel()
    {
        scoreTxts[0].enabled = true;

        activePanel.SetActive(false);

        menuButton.SetActive(true);

        Time.timeScale = 1;
    }

    public void StartButton()
    {
        GameController.instance.StartGame();
    }
}
