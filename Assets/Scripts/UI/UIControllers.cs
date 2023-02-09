
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControllers : MonoBehaviour
{
    public static UIControllers instance;
    public CustomPanelController customPanelController;

    [Header("HomeMenu Panels")]
    public GameObject mainMenuPanel;
    public GameObject levelMenuPanel;
    public GameObject languagePanel;
    public GameObject scorePanel;


    private void Awake()
    {
        // Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        // If instance already exists and it's not this:
        else if (instance != this)

            // Then destroy this           
            Destroy(gameObject);

        // Sets this to not be destroyed when reloading scene
        //DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "HomeMenuScene") 
        {
            levelMenuPanel.SetActive(false);
            mainMenuPanel.SetActive(false);
            languagePanel.SetActive(false);
            scorePanel.SetActive(false);
        }

        customPanelController.GoToPanel("MainMenu");
    }
}
