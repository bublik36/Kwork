using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicSlider : MonoBehaviour
{
    public Slider slider;
    public MusicScript audio;

    private void OnEnable()
    {
        slider = GetComponent<Slider>();
        audio = FindObjectOfType<MusicScript>();
        UpdateSliderOnStart();
    }

    private void Update()
    {
        UpdateSlider();
    }

    private void UpdateSliderOnStart()
    {
        slider.value = audio.audioSource.volume;
    }

    public void UpdateSlider()
    {
        audio.audioSource.volume = slider.value;
        FindObjectOfType<SaveSetting>().SaveMusic();
    }
}
