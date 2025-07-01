using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class SwtichLanguageText : MonoBehaviour
{
   [SerializeField] private Text textUI;
   [SerializeField] private string languageRussia;
   [SerializeField] private string languageEnglish;
   public void SwitchLanguage()
   {
      textUI = GetComponent<Text>();
      if (FindObjectOfType<LanguageObject>().Russia == true)
      {
         textUI.text = languageRussia;
      }
      else if (FindObjectOfType<LanguageObject>().English == true)
      {
         textUI.text = languageEnglish;
      }
   }

   private void Update()
   {
      SwitchLanguage();
   }
}
