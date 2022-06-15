using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    [SerializeField]
    public AudioMixer audioMixer;

    public void setMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }

    public void setEffectsVolume(float volume)
    {
        audioMixer.SetFloat("EffectsVolume", Mathf.Log10(volume) * 20);
    }
}
