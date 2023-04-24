using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    public AudioMixer musicAudioMixer;
    public Slider musicVolumeSlider;
    void Start()
    {
        OnMusicVolumeChange();
    }
    //This function will permit us to change the volume of the slider to being whatever we put it as here.
    public void OnMusicVolumeChange()
    {
        float newVolume = musicVolumeSlider.value;
        if (newVolume <= 0)
        {
            newVolume = -80;
        } else {
            newVolume = Mathf.Log10(newVolume);
            newVolume = newVolume * 20;
        }
        musicAudioMixer.SetFloat("MusicVolume",newVolume);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
