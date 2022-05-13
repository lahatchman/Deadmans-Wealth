using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MouseOverIsland : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private Material islandMouseOver, normalIslandMat;
    [SerializeField] private GameObject islandInformationUI, islandSelected;
    //Public Variables
    public static GameObject island;
    //Private Variables
    private GameManager gameManager;
    private int rndLevel;
    private Transform ship;
    private RectTransform islandUIDimensions;
    private bool uiActive;
    private static bool moveShip;
    private int levelSelected, lastLoadedLevel;
    private static List<int> listOfLevels = new List<int>();
    private static Vector3 previousShipLocation;

    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        ship = GameObject.Find("Ship").transform;
        if (previousShipLocation != Vector3.zero) { ship.transform.position = previousShipLocation; }
    }

    void Start()
    {
        for (int i = 0; i < 9; i++) { listOfLevels.Add(i + 1); }
        ship = GameObject.Find("Ship").transform;
        uiActive = true;
        islandSelected.SetActive(false);
        islandUIDimensions = islandInformationUI.GetComponent<RectTransform>();
        rndLevel = listOfLevels[Random.Range(0, listOfLevels.Count)];
    }

    void Update()
    {
        MoveShip();
    }

    void MoveShip()
    {
        if (moveShip)
        {
            ship.transform.position = Vector3.MoveTowards(ship.transform.position, island.transform.position, 1 * Time.deltaTime);
            ship.transform.LookAt(island.transform.position);
            if (Vector3.Distance(ship.transform.position, island.transform.position) < 0.1f)
            {
                moveShip = false;
                previousShipLocation = ship.transform.position;
                gameManager.RandomEncounter();
                SceneManager.LoadScene(LevelSelectionAlgorithm());
            }
        }
    }

    void OnMouseOver()
    {
        if (uiActive)
        {
            if (!moveShip)
            {
                if (!islandSelected.activeSelf)
                {
                    island = gameObject;
                    island.GetComponent<MeshRenderer>().material = islandMouseOver;
                    islandInformationUI.SetActive(true);
                    islandInformationUI.transform.position = new Vector3((Input.mousePosition.x) - islandUIDimensions.rect.width / 2, (Input.mousePosition.y) + islandUIDimensions.rect.height / 2, Input.mousePosition.z);
                }

                if (Input.GetMouseButtonDown(0))
                {
                    islandInformationUI.SetActive(false);
                    islandSelected.SetActive(true);
                }
            }
        }
    }

    void OnMouseExit()
    {
        island.GetComponent<MeshRenderer>().material = normalIslandMat;
        islandInformationUI.SetActive(false);
    }

    public void AnimateShip()
    {
        uiActive = false;
        islandSelected.SetActive(false);
        moveShip = true;
    }

    int LevelSelectionAlgorithm()
    {
        while (rndLevel == lastLoadedLevel) { rndLevel = listOfLevels[Random.Range(0, 9)]; }

        //selecting islands
        switch (rndLevel)
        {
            case 0:
                //island1
                levelSelected = 2;
                break;
            case 1:
                //island2
                levelSelected = 3;
                break;
            case 2:
                //island3
                levelSelected = 4;
                break;
            case 3:
                //island4
                levelSelected = 5;
                break;
            case 4:
                //island5
                levelSelected = 6;
                break;
            case 5:
                //island6
                levelSelected = 7;
                break;
            case 6:
                //island7
                levelSelected = 8;
                break;
            case 7:
                //island8
                levelSelected = 9;
                break;
            case 8:
                //island9
                levelSelected = 10;
                break;
            case 9:
                //island10
                levelSelected = 11;
                break;
        }
        lastLoadedLevel = levelSelected;
        return levelSelected;
    }
}

