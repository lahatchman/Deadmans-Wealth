using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShipStatus : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private TextMeshProUGUI txtMast, txtBridge, txtDeck, txtHull, txtSelected, txtWoodAmount, txtToolAmount, txtRepair, txtUpgrade, txtShipTier;
    [SerializeField] private GameObject shipMaintenanceUI, upgradeButton, upgradeTitle, upgrade;
    //Private variables
    private GameManager gameManager;
    private int repair, upgradeCost, toolsRequired, max, current, shipPart;
    private bool partSelected;

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        partSelected = false;
        shipPart = 0;
    }

    void Start()
    {
        max = 100;
    }

    void Update()
    {
        SettingText();
        TextColourChange();
        UpgradeCost();
    }

    void TextColourChange()
    {
        if (gameManager.mast > 70)
        {
            txtMast.color = Color.green;
        }
        if (gameManager.bridge > 70)
        {
            txtBridge.color = Color.green;
        }
        if (gameManager.deck > 70)
        {
            txtDeck.color = Color.green;
        }
        if (gameManager.hull > 70)
        {
            txtHull.color = Color.green;
        }
        if (gameManager.mast <= 70 && gameManager.mast >= 50)
        {
            txtMast.color = Color.yellow;
        }
        if (gameManager.bridge <= 70 && gameManager.bridge >= 50)
        {
            txtBridge.color = Color.yellow;
        }
        if (gameManager.deck <= 70 && gameManager.deck >= 50)
        {
            txtDeck.color = Color.yellow;
        }
        if (gameManager.hull <= 70 && gameManager.hull >= 50)
        {
            txtHull.color = Color.yellow;
        }
        if (gameManager.mast <= 49 && gameManager.mast >= 20)
        {
            txtMast.color = Color.magenta;
        }
        if (gameManager.bridge <= 49 && gameManager.bridge >= 20)
        {
            txtBridge.color = Color.magenta;
        }
        if (gameManager.deck <= 49 && gameManager.deck >= 20)
        {
            txtDeck.color = Color.magenta;
        }
        if (gameManager.hull <= 49 && gameManager.hull >= 20)
        {
            txtHull.color = Color.magenta;
        }
        if (gameManager.mast <= 19 && gameManager.mast >= 0)
        {
            txtMast.color = Color.red;
        }
        if (gameManager.bridge <= 19 && gameManager.bridge >= 0)
        {
            txtBridge.color = Color.red;
        }
        if (gameManager.deck <= 19 && gameManager.deck >= 0)
        {
            txtDeck.color = Color.red;
        }
        if (gameManager.hull <= 19 && gameManager.hull >= 0)
        {
            txtHull.color = Color.red;
        }
    }

    void SettingText()
    {
        txtMast.text = gameManager.mast + "%";
        txtBridge.text = gameManager.bridge + "%";
        txtDeck.text = gameManager.deck + "%";
        txtHull.text = gameManager.hull + "%";
        txtWoodAmount.text = gameManager.wood.ToString();
        txtToolAmount.text = gameManager.tools.ToString();
        txtShipTier.text = gameManager.shipTier.ToString();
        if (partSelected == true) { txtRepair.text = repair.ToString() + " Wood & 1 Tool"; }
        txtUpgrade.text = upgradeCost.ToString() + " Wood & " + toolsRequired.ToString() + " Tools";
    }

    public void SelectedMast() 
    { 
        txtSelected.text = "Mast"; 
        partSelected = true;
        shipPart = 0;
        Repair();
    }

    public void SelectedBridge() 
    { 
        txtSelected.text = "Bridge"; 
        partSelected = true;
        shipPart = 1;
        Repair();
    }

    public void SelectedDeck() 
    { 
        txtSelected.text = "Deck"; 
        partSelected = true;
        shipPart = 2;
        Repair();
    }

    public void SelectedHull() 
    { 
        txtSelected.text = "Hull"; 
        partSelected = true;
        shipPart = 3;
        Repair();
    }

    public void CloseUI() 
    { 
        partSelected = false; 
        shipMaintenanceUI.SetActive(false); 
    }
    
    public void RepairClicked()
    {
        switch (shipPart)
        {
            case 0:
                if (gameManager.tools > 0 && gameManager.wood >= repair && gameManager.mast < max)
                {
                    gameManager.mast = max;
                    gameManager.wood -= repair;
                    gameManager.tools--;
                }
                break;

            case 1:
                if (gameManager.tools > 0 && gameManager.wood >= repair && gameManager.bridge < max)
                {
                    gameManager.bridge = max;
                    gameManager.wood -= repair;
                    gameManager.tools--;
                }
                break;

            case 2:
                if (gameManager.tools > 0 && gameManager.wood >= repair && gameManager.deck < max)
                {
                    gameManager.deck = max;
                    gameManager.wood -= repair;
                    gameManager.tools--;
                }
                break;

            case 3:
                if (gameManager.tools > 0 && gameManager.wood >= repair && gameManager.hull < max)
                {
                    gameManager.hull = max;
                    gameManager.wood -= repair;
                    gameManager.tools--;
                }
                break;
        }
    }

    int Repair()
    {
        switch (shipPart)
        {
            case 0:
                current = gameManager.mast;
                repair = (max - current) / 5;
                Mathf.Round(repair);
                break;

            case 1:
                current = gameManager.bridge;
                repair = (max - current) / 5;
                Mathf.Round(repair);
                break;

            case 2:
                current = gameManager.deck;
                repair = (max - current) / 5;
                Mathf.Round(repair);
                break;

            case 3:
                current = gameManager.hull;
                repair = (max - current) / 5;
                Mathf.Round(repair);
                break;
        }
        return repair;
    }

    public void UpgradeClicked()
    {
        switch (gameManager.shipTier)
        {
            case 0:
                if (gameManager.tools >= toolsRequired && gameManager.wood >= upgradeCost) 
                { 
                    gameManager.shipTier++;
                    gameManager.wood -= upgradeCost;
                    gameManager.tools -= toolsRequired;
                }
                else { }
                break;

            case 1:
                if (gameManager.tools >= toolsRequired && gameManager.wood >= upgradeCost) 
                { 
                    gameManager.shipTier++;
                    gameManager.wood -= upgradeCost;
                    gameManager.tools -= toolsRequired;
                }
                else { }
                break;

            case 2:
                if (gameManager.tools >= toolsRequired && gameManager.wood >= upgradeCost) 
                { 
                    gameManager.shipTier++;
                    gameManager.wood -= upgradeCost;
                    gameManager.tools -= toolsRequired;
                }
                else { }
                break;

            case 3:
                if (gameManager.tools >= toolsRequired && gameManager.wood >= upgradeCost) 
                { 
                    gameManager.shipTier++;
                    gameManager.wood -= upgradeCost;
                    gameManager.tools -= toolsRequired;
                }
                else { }
                break;

            case 4:
                if (gameManager.tools >= toolsRequired && gameManager.wood >= upgradeCost) 
                { 
                    gameManager.shipTier++;
                    gameManager.wood -= upgradeCost;
                    gameManager.tools -= toolsRequired;
                }
                else { }
                break;
        }
    }

    void UpgradeCost()
    {
        switch (gameManager.shipTier)
        {
            case 0:
                upgradeCost = 20;
                toolsRequired = 2;
                break;

            case 1:
                upgradeCost = 40;
                toolsRequired = 4;
                break;

            case 2:
                upgradeCost = 60;
                toolsRequired = 6;
                break;

            case 3:
                upgradeCost = 80;
                toolsRequired = 8;
                break;

            case 4:
                upgradeCost = 100;
                toolsRequired = 10;
                break;

            case 5:
                upgradeButton.SetActive(false);
                upgradeTitle.SetActive(false);
                upgrade.SetActive(false);
                break;
        }
    }
}

