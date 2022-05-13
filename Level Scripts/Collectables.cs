using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectables : MonoBehaviour
{
    [SerializeField] private GameObject collectNotification;
    [SerializeField] private TextMeshProUGUI txtInfo;
    private GameManager gameManager;
    private GameObject collectable;
    private ItemCollected itemCollected;
    private bool showCollect;
    private int treeDurability;
    private float timer;

    void Awake()
    {
        collectable = gameObject;
        if (collectable.name.Contains("Tree")) { treeDurability = Random.Range(1, 5); }
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        itemCollected = GameObject.FindGameObjectWithTag("ItemCollectedUI").GetComponent<ItemCollected>();
        showCollect = false;
    }

    void LateUpdate()
    {
        CollectOnPress();
        CollectOnHeldDown();
    }

    private void OnTriggerEnter(Collider other)
    {
        showCollect = true;
        Info();
        Display();
    }

    private void OnTriggerExit(Collider other)
    {
        showCollect = false;
        Display();
    }

    private void CollectOnHeldDown()
    {
        if (showCollect && Input.GetKey(KeyCode.F)) { CollectableTypeHeld(); }
    }

    private void CollectOnPress()
    {
        if (showCollect && Input.GetKeyDown(KeyCode.F)) { CollectableTypePressed(); }
    }

    private void Display()
    {
        if (showCollect) { collectNotification.SetActive(true); }
        else { collectNotification.SetActive(false); }
    }

    private void CollectableTypePressed()
    {
        switch (collectable.name)
        {
            case string a when a.Contains("Bush"):
                gameManager.food ++;
                itemCollected.Food();
                collectNotification.SetActive(false);
                Destroy(collectable);
                break;

            case string b when b.Contains("Tree"):
                gameManager.wood ++;
                treeDurability --;
                itemCollected.Wood();
                if (treeDurability <= 0) 
                { 
                    collectNotification.SetActive(false); 
                    Destroy(collectable); 
                }
                break;

            case string c when c.Contains("Tool"):
                gameManager.tools ++;
                collectNotification.SetActive(false);
                itemCollected.Tool();
                Destroy(collectable);
                break;
        }
    }
    
    private void CollectableTypeHeld()
    {
        switch (collectable.name)
        {
            case string a when a.Contains("Water"):
                if (gameManager.water < 100) 
                {
                    timer += 1.0f * Time.deltaTime;
                    if (timer > 0.5f)
                    {
                        gameManager.water += 1;
                        itemCollected.Water();
                        timer = 0;
                    }
                }
                break;
        }
    }

    private void Info()
    {
        switch (collectable.name)
        {
            case string a when a.Contains("Bush"):
                txtInfo.text = "Collect Food";
                txtInfo.color = Color.green;
                break;

            case string b when b.Contains("Water"):
                txtInfo.text = "Fill Flask";
                txtInfo.color = Color.blue;
                break;

            case string c when c.Contains("Tree"):
                txtInfo.text = "Chop Wood";
                txtInfo.color = Color.red;
                break;

            case string d when d.Contains("Tool"):
                txtInfo.text = "Obtain Tool";
                txtInfo.color = Color.magenta;
                break;
        }
    }
}

