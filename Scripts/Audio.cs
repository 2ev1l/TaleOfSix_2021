using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    public AudioMixer am;

    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("MusicVol", sliderValue);
    }
    public AudioMixer sm;

    public void SoundVolume(float sliderValue)
    {
        sm.SetFloat("SoundVol", sliderValue);
    }

}
