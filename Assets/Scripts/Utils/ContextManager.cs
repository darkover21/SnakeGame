using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to store necessary variables
/// </summary>
public static class ContextManager
{
    // Game Settings
    public static bool isMusicEnabled = true;
    public static float musicVolume = 0.5f;
    public static bool isAudioEffectEnabled = true;
    public static float audioEffectsVolume = 0.5f;
    public static Dictionary<string, string> englishDictionary = new Dictionary<string, string>();
    public static Dictionary<string, string> spanishDictionary = new Dictionary<string, string>();
    public static string language = "spanish";
    public static int dificulty = 1;

}

