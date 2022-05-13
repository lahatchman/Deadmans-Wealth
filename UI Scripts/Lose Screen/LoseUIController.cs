using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoseUIController : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] private TextMeshProUGUI txtCauseOfDeath;
    //Private Variables
    private GameManager gameManager;

    void Awake() 
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Start() 
    { 
        TextUpdate();

        var gameManagers = GameObject.FindObjectsOfType<GameManager>();
        var playerMaintenanceManager = GameObject.FindGameObjectsWithTag("PlayerMaintenance");


        //Destroying GameManager and PlayerMaintenanceManager on lose
        for (int i = 0; i < gameManagers.Length; i++)
        {
            if (gameManagers.Length > 0)
            { 
                Destroy(gameManagers[0].gameObject);
                Destroy(playerMaintenanceManager[0].gameObject);
            }
        }

        Cursor.lockState = CursorLockMode.None;
    }

    void TextUpdate()
    {
        if (gameManager.health <= 0)
        {
            txtCauseOfDeath.text = "Your Wounds";
            txtCauseOfDeath.color = new Color32(255, 0, 0, 255);
        }
        if (gameManager.hunger <= 0)
        {
            txtCauseOfDeath.text = "Starvation";
            txtCauseOfDeath.color = new Color32(255, 128, 0, 255);
        }
        if (gameManager.thirst <= 0)
        {
            txtCauseOfDeath.text = "Dehydration";
            txtCauseOfDeath.color = new Color32(0, 0, 255, 255);
        }
        if (gameManager.mast <= 0 || gameManager.bridge <= 0 || gameManager.deck <= 0 || gameManager.hull <= 0)
        {
            txtCauseOfDeath.text = "Ship Decay";
            txtCauseOfDeath.color = new Color32(255, 0, 127, 255);
        }
    }

    public void ReturntoMenu() 
    {
        SceneManager.LoadScene(0);
    }
}
