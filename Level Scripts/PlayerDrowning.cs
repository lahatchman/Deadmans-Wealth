using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrowning : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private GameObject underWater;
    [SerializeField] private float drowningStart, drowningInterval;
    [SerializeField] private int drowningDamage;
    //Private Variables
    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        underWater.SetActive(true);
        if (other.name.Contains("Player")) { InvokeRepeating("Drowning", drowningStart, drowningInterval); }
    }

    void OnTriggerExit(Collider other)
    {
        underWater.SetActive(false);
        if (other.name.Contains("Player")) { CancelInvoke("Drowning"); }
    }

    void Drowning()
    { 
        gameManager.health -= drowningDamage;
        gameManager.SliderUpdate(gameManager.txtHealth, gameManager.sHealth, "Health: ", gameManager.health, "/100");
    }
}
