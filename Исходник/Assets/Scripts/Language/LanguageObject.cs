using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
public class LanguageObject : MonoBehaviour
{
    public bool Russia = true;
    public bool English = false;
    private string Language;
    private void Awake()
    {
        if (YG2.lang == "en")
        {
            SwitchLanguageOnEnglish();
        }
        else if (YG2.lang == "ru")
        {
            SwitchLanguageOnRussia();
        }
    }
    public void SwitchLanguageOnRussia()
    {
        YG2.envir.language = "ru";
        YG2.SwitchLanguage("ru");
        YG2.lang = "ru";
        Russia = true;
        English = false;
    }
    public void SwitchLanguageOnEnglish()
    {
        YG2.envir.language = "en";
        YG2.lang = "en";
        YG2.SwitchLanguage("en");
        Russia = false;
        English = true;
    }
}
