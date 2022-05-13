using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UINavigation : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private GameObject mainMenu, saveData, controls, credits;
    //Private Variables
    private GameConstants gameConstants;
    private SaveDataDisplay saveDataDisplay;
    private PersistenceManager persistenceManager;

    void Awake()
    {
        gameConstants = GameObject.FindGameObjectWithTag("GameConstants").GetComponent<GameConstants>();
        saveDataDisplay = GameObject.FindGameObjectWithTag("MainMenuUI").GetComponent<SaveDataDisplay>();
        persistenceManager = GameObject.FindGameObjectWithTag("MainMenuUI").GetComponent<PersistenceManager>();
        DontDestroyOnLoad(gameConstants);
    }

    void Start()
    {
        if (gameConstants.gameReturn)
        {
            var gameManagers = GameObject.FindObjectsOfType<GameManager>();
            var playerMaintenanceManager = GameObject.FindGameObjectsWithTag("PlayerMaintenance");

            //Destroying GameManager and PlayerMaintenanceManager on returning to main menu
            for (int i = 0; i < gameManagers.Length; i++)
            {
                if (gameManagers.Length > 0)
                {
                    Destroy(gameManagers[0].gameObject);
                    Destroy(playerMaintenanceManager[0].gameObject);
                }
            }
            gameConstants.gameReturn = false;
        }
    }

    public void BeginGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SaveData()
    {
        saveDataDisplay.UpdateSaveDataText();
        saveData.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void SDReturn()
    {
        mainMenu.SetActive(true);
        saveData.SetActive(false);
    }

    public void ResetData()
    {
        persistenceManager.ResetProgress();
        mainMenu.SetActive(true);
        saveData.SetActive(false);
    }

    public void Controls()
    {
        controls.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void ConReturn()
    {
        mainMenu.SetActive(true);
        controls.SetActive(false);
    }

    public void Credits() 
    {
        credits.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CReturn()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
