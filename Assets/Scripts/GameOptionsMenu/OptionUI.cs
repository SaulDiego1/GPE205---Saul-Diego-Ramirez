using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    public AudioMixer mainAudioMixer;
    public Slider mainVolumeSlider;

    void Start()
    {
        OnMainVolumeChange();
    }

    //This function will permit us to change the volume of the slider to being whatever we put it as here.
    public void OnMainVolumeChange()
    {
        float newVolume = mainVolumeSlider.value;
        if (newVolume <= 0)
        {
            newVolume = -80;
        } else {
            newVolume = Mathf.Log10(newVolume);
            newVolume = newVolume * 20;
        }
        mainAudioMixer.SetFloat("MainVolume",newVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
