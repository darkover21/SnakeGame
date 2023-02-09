using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextTranslator : MonoBehaviour
{
    TextMeshProUGUI textMeshProText;
    Text textText;
    string translation = "";
    void Start()
    {
        Controllers.instance.languageController.translatorList.Add(this);
        Debug.Log(Controllers.instance.languageController.translatorList.Count);
        textMeshProText = GetComponent<TextMeshProUGUI>();
        textText = GetComponent<Text>();
        translation = Controllers.instance.languageController.GetTranslation(GetText());
        if (translation != "") { SetText(translation); }
        else { Debug.Log(GetText() + "not found"); }
    }

    public void UpdateTranslation() {
        translation = Controllers.instance.languageController.GetTranslation(GetText());
        if (translation != "") SetText(translation);
    }

    private void SetText(string content) 
    {
        if (textText != null) textText.text = content;
        if (textMeshProText != null) textMeshProText.text = content;
    }

    private string GetText()
    {
        string content = "";
        if (textText != null) content = textText.text ;
        if (textMeshProText != null) content = textMeshProText.text;
        return content;
    }


}
