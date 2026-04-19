using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private float currVol;
    [SerializeField] private Toggle toggle;

    void Start() 
    {
        if (PlayerPrefs.GetInt("IsOn") == 1)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
    }

    public void Mute(bool isOn)
    {
        if (isOn)
        {
            mixer.SetFloat("MusicVol", -80f);
            PlayerPrefs.SetInt("IsOn", 1);
        }
        else
        {
            mixer.SetFloat("MusicVol", 0f);
            PlayerPrefs.SetInt("IsOn", 0);
            MusicPlayer.instance.PlayClick();
        }
    }
}
