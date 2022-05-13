using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipStatusWarning : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtPartDamaged, txtDamageTaken, txtPartDecreased, txtDurabilityDecrease;
    [SerializeField] private GameObject warningUI, attackedPanel;
    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        SetText();
        if (gameManager.wasAttacked == true) { attackedPanel.SetActive(true); }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) { gameManager.wasAttacked = false; warningUI.SetActive(false); }
    }

    void SetText()
    {
        txtPartDamaged.text = gameManager.damagedShipPart;
        txtDamageTaken.text = gameManager.shipDamage.ToString();
        txtPartDecreased.text = gameManager.shipDuirabilityDecrease;
        txtDurabilityDecrease.text = gameManager.durabilityDecrease.ToString();
    }
}
