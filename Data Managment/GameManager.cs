using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private GameObject gameManager, playerMaintenanceUI;
    [SerializeField] public int health, hunger, thirst, wood, food, water, tools, mast, bridge, deck, hull, shipTier;
    [SerializeField] private float hungerDecayTime, thirstDecayTime;
    [SerializeField] public TextMeshProUGUI txtHealth, txtHunger, txtThirst;
    [SerializeField] public Slider sHealth, sHunger, sThirst;
    //Public Variables
    public string damagedShipPart, shipDuirabilityDecrease;
    public int shipDamage, durabilityDecrease;
    public bool wasAttacked;
    //Private Variables
    private int randDepletion, randEncounterChance, randShipPart;
    private Scene currentScene;

    void Awake()
    {
        playerMaintenanceUI = GameObject.FindGameObjectWithTag("PlayerMaintenance");
        currentScene = SceneManager.GetActiveScene();

        DontDestroyOnLoad(gameManager);
        DontDestroyOnLoad(playerMaintenanceUI);
    }

    void Start()
    {
        InvokeRepeating("HungerDepletion", hungerDecayTime, hungerDecayTime);
        InvokeRepeating("ThirstDepletion", thirstDecayTime, thirstDecayTime);

        var gameManagers = GameObject.FindObjectsOfType<GameManager>();
        var playerMaintenanceManager = GameObject.FindGameObjectsWithTag("PlayerMaintenance");

        //keeping the GameManager and PlayerMaintenanceUI a singleton during runtime
        for (int i = 0; i < gameManagers.Length; i++)
        {
            if (gameManagers.Length > 1)
            {
                Destroy(gameManagers[1].gameObject);
                Destroy(playerMaintenanceManager[1].gameObject);
            }
        }
    }

    void Update()
    {
        CurrentSceneCheck();
        Death();
    }

    void HungerDepletion()
    {
        randDepletion = Random.Range(1, 5);
        hunger -= randDepletion;
        SliderUpdate(txtHunger, sHunger, "Hunger: ", hunger, "/100");
    }

    void ThirstDepletion()
    {
        randDepletion = Random.Range(1, 10);
        thirst -= randDepletion;
        SliderUpdate(txtThirst, sThirst, "Thirst: ", thirst, "/100");
    }

    public void SliderUpdate(TextMeshProUGUI t, Slider s, string type, int val, string max)
    {
        s.value = val;
        t.text = type + val.ToString() + max;
    }

    void CurrentSceneCheck()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Mission Selection (Node Map)") { Cursor.lockState = CursorLockMode.None; }
    }

    public void RandomEncounter()
    {
        randEncounterChance = Random.Range(0, 100);

        switch (shipTier)
        {
            case 0:
                shipDamage = 20;
                wasAttacked = true;
                ShipDamage();
                ShipDurabilityDecrease();
                break;

            case 1:
                shipDamage = 17;
                if (randEncounterChance <= 80) { wasAttacked = true; ShipDamage(); }
                else { wasAttacked = false; }
                ShipDurabilityDecrease();
                break;

            case 2:
                shipDamage = 14;
                if (randEncounterChance <= 60) { wasAttacked = true; ShipDamage(); }
                else { wasAttacked = false; }
                ShipDurabilityDecrease();
                break;

            case 3:
                shipDamage = 11;
                if (randEncounterChance <= 40) { wasAttacked = true; ShipDamage(); }
                else { wasAttacked = false; }
                ShipDurabilityDecrease();
                break;

            case 4:
                shipDamage = 8;
                if (randEncounterChance <= 20) { wasAttacked = true; ShipDamage(); }
                else { wasAttacked = false; }
                ShipDurabilityDecrease();
                break;

            case 5:
                shipDamage = 5;
                wasAttacked = false;
                ShipDurabilityDecrease();
                break;
        }
    }

    void ShipDamage()
    {
        randShipPart = Random.Range(0, 3);

        switch (randShipPart)
        {
            case 0:
                mast -= shipDamage;
                damagedShipPart = "Mast";
                break;

            case 1:
                bridge -= shipDamage;
                damagedShipPart = "Bridge";
                break;

            case 2:
                deck -= shipDamage;
                damagedShipPart = "Deck";
                break;

            case 3:
                hull -= shipDamage;
                damagedShipPart = "Hull";
                break;
        }
    }

    void ShipDurabilityDecrease()
    {
        randShipPart = Random.Range(0, 3);
        durabilityDecrease = Random.Range(1, 10);

        switch (randShipPart)
        {
            case 0:
                mast -= durabilityDecrease;
                shipDuirabilityDecrease = "Mast";
                break;

            case 1:
                bridge -= durabilityDecrease;
                shipDuirabilityDecrease = "Bridge";
                break;

            case 2:
                deck -= durabilityDecrease;
                shipDuirabilityDecrease = "Deck";
                break;

            case 3:
                hull -= durabilityDecrease;
                shipDuirabilityDecrease = "Hull";
                break;
        }
    }

    void Death()
    {
        if (health <= 0 || hunger <= 0 || thirst <= 0 || mast <= 0 || bridge <= 0 || deck <= 0 || hull <= 0)
        {
            SceneManager.LoadScene(12);
        }
    }
}

