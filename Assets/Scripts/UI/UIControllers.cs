
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControllers : MonoBehaviour
{
    public static UIControllers instance;

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

    }
}
