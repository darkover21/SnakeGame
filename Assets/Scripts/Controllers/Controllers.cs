using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controllers : MonoBehaviour
{

    public static Controllers instance = null;

    public AnalyticsController analyticsController;
    public MusicPlayerController musicPlayerController;
    public CacheController cacheController;
    public AppController appController;
    public LanguageController languageController;
    public LevelController levelController;

    private void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        //DontDestroyOnLoad(this);
    }



}