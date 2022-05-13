using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnToNodeMap : MonoBehaviour
{
    [SerializeField] private GameObject returnNotification;
    private bool returnToNodeMap, showReturn;

    void Awake()
    {
        returnToNodeMap = false;
        showReturn = false;
    }

    void Update()
    {
        if (returnToNodeMap)
        {
            ReturnToMap();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (showReturn)
        {
            returnNotification.SetActive(true);
            returnToNodeMap = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        returnNotification.SetActive(false);
        returnToNodeMap = false;
        showReturn = true;
    }

    private void ReturnToMap()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            returnNotification.SetActive(false);
            SceneManager.LoadScene(1);
        }
    }
}
