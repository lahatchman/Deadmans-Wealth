using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseIslandSelectedUI : MonoBehaviour
{
    [SerializeField] private GameObject islandUI;

    public void CloseIslandUI()
    {
        islandUI.SetActive(false);
    }
}
