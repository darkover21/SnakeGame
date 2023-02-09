using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Word{
    public string key;
    public string word;
}

public class LanguageController : MonoBehaviour
{
    
    public List<Word> englishStrings;
    public List<Word> spanishStrings;
   
    List<string> languages = new List<string>();
    [HideInInspector]
    public List<TextTranslator> translatorList = new List<TextTranslator>();
   
    void LoadDictionary(List<Word> wordbank, Dictionary<string, string> dictionary)
    {
        foreach (Word wordItem in wordbank) {
            dictionary.Add(wordItem.key, wordItem.word);
        }

    }

    private void Start() { 
        string currentScene = SceneManager.GetActiveScene().name;
        Debug.Log(ContextManager.language);
      /*  if (dropdown != null) {
            languages.Add("english");
            languages.Add("spanish");
            foreach (var language in languages) {
                dropdown.options.Add(new Dropdown.OptionData() { text = language });
            }
            dropdown.onValueChanged.AddListener(delegate { OnLanguageChanged(); });
        } */

        if(currentScene != "SplashWindowScene" ) return;
        // Load english dictionary
        LoadDictionary(englishStrings, ContextManager.englishDictionary);

        // Load spanish dictionary
        LoadDictionary(spanishStrings, ContextManager.spanishDictionary);

        //This checks if your computer's operating system is in the French language
        if (Application.systemLanguage == SystemLanguage.Spanish)
        {
            //Outputs into console that the system is Spanish
            Debug.Log("This system is in Spanish. ");
            ContextManager.language = "spanish";
        }
        //Otherwise, if the system is English, output the message in the console
        else if (Application.systemLanguage == SystemLanguage.English)
        {
            Debug.Log("This system is in English. ");
            ContextManager.language = "english";
        }
        else 
        {
            Debug.Log("This system is in Other language so We use english. ");
            ContextManager.language = "english";
        }
    }

    public string GetTranslation(string key) {
        string translation = "";
        switch (ContextManager.language) {

            case "english":
                ContextManager.englishDictionary.TryGetValue(key, out translation);
                break;

            case "spanish":
                ContextManager.spanishDictionary.TryGetValue(key, out translation);
                break;
        }
        return translation;

    }

    // This event is called on dropdown value changed
    public void OnLanguageChanged() {
        
        //ContextManager.language = dropdown.options[dropdown.value].text;
        Controllers.instance.levelController.ReloadLevel();
        //RefreshAllTranslations();
    }


    public void RefreshAllTranslations() {
        foreach (TextTranslator translator in translatorList) {

            translator.UpdateTranslation();
        
        }
    
    }
}
