using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveDataDisplay : MonoBehaviour
{
    //Serialized Varables
    [SerializeField] private TextMeshProUGUI txtHealth, txtHunger, txtThirst, txtFood, txtWater, txtWood, txtTools, txtShipTier;
    //Private Variables
    private PersistenceManager persistenceManager;

    void Awake()
    {
        persistenceManager = GameObject.FindGameObjectWithTag("MainMenuUI").GetComponent<PersistenceManager>();
    }

    void SaveData()
    {
        txtHealth.text = persistenceManager.health.ToString() + "/100";
        txtHunger.text = persistenceManager.hunger.ToString() + "/100";
        txtThirst.text = persistenceManager.thirst.ToString() + "/100";
        txtFood.text = persistenceManager.food.ToString();
        txtWater.text = persistenceManager.water.ToString();
        txtWood.text = persistenceManager.wood.ToString();
        txtTools.text = persistenceManager.tools.ToString();
        txtShipTier.text = persistenceManager.shipTier.ToString();
    }

    public void UpdateSaveDataText()
    {
        if (PlayerPrefs.HasKey("PlayerHasSaved")) 
        {
            SaveData();
        }
        else
        {
            txtHealth.text = "N/A";
            txtHunger.text = "N/A";
            txtThirst.text = "N/A";
            txtFood.text = "N/A";
            txtWater.text = "N/A";
            txtWood.text = "N/A";
            txtTools.text = "N/A";
            txtShipTier.text = "N/A";
        }
    }

}
