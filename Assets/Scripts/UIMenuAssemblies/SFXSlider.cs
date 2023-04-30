using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour
{
    public AudioMixer SFXAudioMixer;
    public Slider SFXVolumeSlider;
    void Start()
    {
        OnSoundEffectsVolumeChange();
    }
    //This function will permit us to change the volume of the slider to being whatever we put it as here.
    public void OnSoundEffectsVolumeChange()
    {
        float newVolume = SFXVolumeSlider.value;
        if (newVolume <= 0)
        {
            newVolume = -80;
        } else {
            newVolume = Mathf.Log10(newVolume);
            newVolume = newVolume * 20;
        }
        SFXAudioMixer.SetFloat("SFXVolume",newVolume);
    }
}
