using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance;
    [SerializeField] private AudioSource gameMusic;
    [SerializeField] private AudioSource mainMenuMusic;
    [SerializeField] private AudioSource click;


    void Awake() 
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            mainMenuMusic.Play();
        }
    }

    public void PlayClick()
    {
        click.Play();
    }

    public void PlayGameMusic()
    {
        if (mainMenuMusic.isPlaying)
            mainMenuMusic.Stop();
        gameMusic.Stop();
        gameMusic.Play();
    }

    public void PlayMainMenuMusic()
    {
        if (gameMusic.isPlaying)
            gameMusic.Stop();
        mainMenuMusic.Stop();
        mainMenuMusic.Play();
    }

    public void MuteForAd()
    {
        gameMusic.Stop();
    }
}

