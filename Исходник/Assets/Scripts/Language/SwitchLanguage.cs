using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLanguage : MonoBehaviour
{
    [SerializeField] private GameObject ObjectLanguage;
    [SerializeField] private LanguageObject languageObject;
    private void Start()
    {
        languageObject = FindObjectOfType<LanguageObject>();
        if (languageObject == null)
        {
            Instantiate(ObjectLanguage, Vector3.zero, Quaternion.identity);
            languageObject = FindObjectOfType<LanguageObject>();
            DontDestroyOnLoad(languageObject.gameObject);
        }
    }

    public void SwitchOnRussia()
    {
        languageObject.SwitchLanguageOnRussia();
    }

    public void SwitchOnEnglish()
    {
        languageObject.SwitchLanguageOnEnglish();
    }
}
