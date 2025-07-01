using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SwitchLanguageDropDown : MonoBehaviour
{
    [SerializeField] private string[] languageRussia;
    [SerializeField] private string[] languageEnglish;
    [SerializeField] private Dropdown dropDown;
    [SerializeField] private Text _text;
    [SerializeField] private GameObject Template;
    [SerializeField] private int Value;
    private Graphics graphics;

    private void Start()
    {
        graphics = FindObjectOfType<Graphics>();
    }

    public void SwitchLanguage()
    {
        dropDown = GetComponent<Dropdown>();
        if (FindObjectOfType<LanguageObject>().Russia == true)
        {
            dropDown.options[0].text = languageRussia[0];
            dropDown.options[1].text = languageRussia[1];
            dropDown.options[2].text = languageRussia[2];
        }
        else if (FindObjectOfType<LanguageObject>().English == true)
        {
            dropDown.options[0].text = languageEnglish[0];
            dropDown.options[1].text = languageEnglish[1];
            dropDown.options[2].text = languageEnglish[2];
        }
    }

    private void Update()
    {
        SwitchLanguageLabel();
        SwitchLanguage();
    }

    private void SwitchLanguageLabel()
    {
        if (FindObjectOfType<LanguageObject>().Russia == true)
        {
            
            if (graphics.GraphLvl == 0)
            {
                _text.text = languageRussia[0];
                
            }
            else if (graphics.GraphLvl == 1)
            {
                _text.text = languageRussia[1];
            }

            else if (graphics.GraphLvl == 2)
            {
                _text.text = languageRussia[2];
            }
        }
        else if (FindObjectOfType<LanguageObject>().English == true)
        {
            if (graphics.GraphLvl == 0)
            {
                _text.text = languageEnglish[0];
            }

            else if (graphics.GraphLvl == 1)
            {
                _text.text = languageEnglish[1];
            }

            else if (graphics.GraphLvl == 2)
            {
                _text.text = languageEnglish[2];
            }
        }
    }
}
