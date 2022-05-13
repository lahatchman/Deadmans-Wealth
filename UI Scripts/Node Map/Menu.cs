using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private GameObject menuUI, menuButton, shipMaintenanceUI;
    //Private Variables
    private GameConstants gameConstants;

    void Awake()
    {
        gameConstants = GameObject.FindGameObjectWithTag("GameConstants").GetComponent<GameConstants>();
    }

    public void OpenMenu()
    {
        menuButton.SetActive(false);
        menuUI.SetActive(true);
    }

    public void CloseMenu()
    {
        menuUI.SetActive(false);
        menuButton.SetActive(true);
    }

    public void OpenShipUI()
    {
        shipMaintenanceUI.SetActive(true);
    }

    public void MainMenuReturn()
    {
        gameConstants.gameReturn = true;
        SceneManager.LoadScene(0);
    }
}
