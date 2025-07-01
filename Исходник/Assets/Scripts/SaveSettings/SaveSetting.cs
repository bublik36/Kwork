using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SaveSetting : MonoBehaviour
{
    [SerializeField] private Dropdown _GraphDropdown;
    [SerializeField] private MusicScript _MusicSlider;

    private void Start()
    {
        _MusicSlider = FindObjectOfType<MusicScript>();
        LoadGraphic();
        LoadMusic();
    }

    public void SaveGraphic()
    {
        PlayerPrefs.SetInt("GraphLvl", _GraphDropdown.value);
    }

    public void SaveMusic()
    {
        PlayerPrefs.SetFloat("MusicVolume", _MusicSlider.audioSource.volume);
    }
    

    public void LoadGraphic()
    {
        if (PlayerPrefs.HasKey("GraphLvl"))
        {
            _GraphDropdown.value = PlayerPrefs.GetInt("GraphLvl", _GraphDropdown.value);
        }
        else
        {
            return;
        }
    }

    public void LoadMusic()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            _MusicSlider.audioSource.volume = PlayerPrefs.GetFloat("MusicVolume", _MusicSlider.audioSource.volume);
        }
        else
        {
            return;
        }
    }
}
