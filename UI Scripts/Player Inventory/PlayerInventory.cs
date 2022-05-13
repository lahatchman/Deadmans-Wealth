using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    //Serialized variables
    [SerializeField] private TextMeshProUGUI txtFood, txtWater, txtWood, txtTool, txtHunger, txtThirst;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private int foodIncrease;
    //Private variables
    private GameManager gameManager;
    private int thirstIncrease;
    private bool inventoryUpdate;

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        inventoryUpdate = false;
    }

    void Update()
    {
        if (inventoryUpdate)
        {
            TextUpdate();
            inventoryUpdate = false;
        }
    }

    void TextUpdate()
    {
        ResourceAmount(txtFood, gameManager.food);
        ResourceAmount(txtWater, gameManager.water);
        ResourceAmount(txtWood, gameManager.wood);
        ResourceAmount(txtTool, gameManager.tools);
        ResourceAmount(txtHunger, gameManager.hunger);
        ResourceAmount(txtThirst, gameManager.thirst);
    }

    void ResourceAmount(TextMeshProUGUI t, int val)
    {
        t.text = val.ToString();
    }

    public void OpenInventory()
    {
        inventoryUI.SetActive(true);
        inventoryUpdate = true;
    }

    public void CloseInventory()
    {
        inventoryUI.SetActive(false);
        inventoryUpdate = false;
    }

    public void Hunger()
    {
        if (gameManager.food > 0 && gameManager.hunger < 100)
        {
            gameManager.hunger += foodIncrease;

            if (gameManager.health < 100) { gameManager.health += 10; MaxCheck(gameManager.health); }

            if (gameManager.hunger > 100) { gameManager.hunger = 100; }

            gameManager.SliderUpdate(gameManager.txtHunger, gameManager.sHunger, "Hunger: ", gameManager.hunger, "/100");
            gameManager.SliderUpdate(gameManager.txtHealth, gameManager.sHealth, "Health: ", gameManager.health, "/100");
            txtHunger.text = gameManager.hunger.ToString();
            gameManager.food--;
            txtFood.text = gameManager.food.ToString();
        }
        else { }
    }

    public void Thirst()
    {
        if (gameManager.water > 0 && gameManager.thirst < 100)
        {
            gameManager.thirst += gameManager.water;

            if (gameManager.health < 100) { gameManager.health += 5; MaxCheck(gameManager.health); }

            if (gameManager.thirst > 100) { gameManager.thirst = 100; }

            gameManager.SliderUpdate(gameManager.txtThirst, gameManager.sThirst, "Thirst: ", gameManager.thirst, "/100");
            gameManager.SliderUpdate(gameManager.txtHealth, gameManager.sHealth, "Health: ", gameManager.health, "/100");
            thirstIncrease = gameManager.water;
            gameManager.water -= thirstIncrease;
            txtThirst.text = gameManager.thirst.ToString();
            txtWater.text = gameManager.water.ToString();
        }
        else { }
    }

    void MaxCheck(int val)
    {
        if (val > 100) { val = 100; }
    }
}

