using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    //Public Variables
    public int health, hunger, thirst, wood, food, water, tools, mast, bridge, deck, hull, shipTier, playerHasSaved;
    //Private Variables
    private GameManager gameManager;


    void Awake()
    {
        LoadSavedData();
        if (GameObject.FindGameObjectWithTag("GameManager"))
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            playerHasSaved = 0;
            if (PlayerPrefs.HasKey("PlayerHasSaved")) { LoadProgress(); }
        } 
    }

    void Start()
    {
        InvokeRepeating("SettingSavedVariables", 60.0f, 60.0f);
    }

    void SettingSavedVariables()
    {
        if (GameObject.FindGameObjectWithTag("GameManager"))
        {
            health = gameManager.health;
            hunger = gameManager.hunger;
            thirst = gameManager.thirst;
            food = gameManager.food;
            water = gameManager.water;
            wood = gameManager.wood;
            tools = gameManager.tools;
            mast = gameManager.mast;
            bridge = gameManager.bridge;
            deck = gameManager.deck;
            hull = gameManager.hull;
            shipTier = gameManager.shipTier;
        }
    }

    public void SaveProgress()
    {
        SettingSavedVariables();
        PlayerPrefs.SetInt("PlayerHasSaved", playerHasSaved);
        PlayerPrefs.SetInt("PlayerHealth", health);
        PlayerPrefs.SetInt("PlayerHunger", hunger);
        PlayerPrefs.SetInt("PlayerThirst", thirst);
        PlayerPrefs.SetInt("PlayerFood", food);
        PlayerPrefs.SetInt("PlayerWater", water);
        PlayerPrefs.SetInt("PlayerWood", wood);
        PlayerPrefs.SetInt("PlayerTools", tools);
        PlayerPrefs.SetInt("PlayerMast", mast);
        PlayerPrefs.SetInt("PlayerBridge", bridge);
        PlayerPrefs.SetInt("PlayerDeck", deck);
        PlayerPrefs.SetInt("PlayerHull", hull);
        PlayerPrefs.SetInt("PlayerShipTier", shipTier);
        PlayerPrefs.Save();
    }

    void LoadSavedData()
    {
        health = PlayerPrefs.GetInt("PlayerHealth");
        hunger = PlayerPrefs.GetInt("PlayerHunger");
        thirst = PlayerPrefs.GetInt("PlayerThirst");
        food = PlayerPrefs.GetInt("PlayerFood");
        water = PlayerPrefs.GetInt("PlayerWater");
        wood = PlayerPrefs.GetInt("PlayerWood");
        tools = PlayerPrefs.GetInt("PlayerTools");
        mast = PlayerPrefs.GetInt("PlayerMast");
        bridge = PlayerPrefs.GetInt("PlayerBridge");
        deck = PlayerPrefs.GetInt("PlayerDeck");
        hull = PlayerPrefs.GetInt("PlayerHull");
        shipTier = PlayerPrefs.GetInt("PlayerShipTier");
    }

    void LoadProgress()
    {
        LoadSavedData();
        gameManager.health = health;
        gameManager.hunger = hunger;
        gameManager.thirst = thirst;
        gameManager.food = food;
        gameManager.water = water;
        gameManager.wood = wood;
        gameManager.tools = tools;
        gameManager.mast = mast;
        gameManager.bridge = bridge;
        gameManager.deck = deck;
        gameManager.hull = hull;
        gameManager.shipTier = shipTier;
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        health = 0;
        hunger = 0;
        thirst = 0;
        food = 0;
        water = 0;
        wood = 0;
        tools = 0;
        mast = 0;
        bridge = 0;
        deck = 0;
        hull = 0;
        shipTier = 0;
    }
}

