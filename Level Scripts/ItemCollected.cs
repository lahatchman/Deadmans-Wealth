using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollected : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtItemCollected;
    [SerializeField] private GameObject itemCollection, foodImage, waterImage, woodImage, toolImage;
    private GameManager gameManager;
    private int collectable;
    private bool canPlay;

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void Food()
    {
        collectable = 0;
        waterImage.SetActive(false);
        woodImage.SetActive(false);
        toolImage.SetActive(false);
        txtItemCollected.text = gameManager.food.ToString();
        StopCoroutine(UIVisibleTime());
        itemCollection.SetActive(true);
        foodImage.SetActive(true);
        StartCoroutine(UIVisibleTime());
    }

    public void Water()
    {
        collectable = 1;
        foodImage.SetActive(false);
        woodImage.SetActive(false);
        toolImage.SetActive(false);
        txtItemCollected.text = gameManager.water.ToString();
        if (!itemCollection.activeInHierarchy) { itemCollection.SetActive(true); }
        if (!waterImage.activeInHierarchy) { waterImage.SetActive(true);}
        if (!canPlay) 
        {
            StartCoroutine(UIVisibleTime());
            canPlay = true;
        }
    }

    public void Wood()
    {
        collectable = 2;
        foodImage.SetActive(false);
        waterImage.SetActive(false);
        toolImage.SetActive(false);
        txtItemCollected.text = gameManager.wood.ToString();
        StopCoroutine(UIVisibleTime());
        itemCollection.SetActive(true);
        woodImage.SetActive(true);
        StartCoroutine(UIVisibleTime());
    }

    public void Tool()
    {
        collectable = 3;
        foodImage.SetActive(false);
        waterImage.SetActive(false);
        woodImage.SetActive(false);
        txtItemCollected.text = gameManager.tools.ToString();
        StopCoroutine(UIVisibleTime());
        itemCollection.SetActive(true);
        toolImage.SetActive(true);
        StartCoroutine(UIVisibleTime());
    }

    IEnumerator UIVisibleTime()
    {
        yield return new WaitForSeconds(5.0f);
        switch (collectable)
        {
            case 0:
                foodImage.SetActive(false);
                break;
            case 1:
                waterImage.SetActive(false);
                break;
            case 2:
                woodImage.SetActive(false);
                break;
            case 3:
                toolImage.SetActive(false);
                break;
        }
        itemCollection.SetActive(false);
        canPlay = false;
    }
}
