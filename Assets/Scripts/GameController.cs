using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using GoogleMobileAds.Api;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    private InterstitialAd interstitial;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject losingUI;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI highScore;
    public bool gameOver = false;
    public bool jumped = false;
    public int scoreNum;
    private int highScoreNum = -1;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Instantiate(player, new Vector3(-3.2f, 2.1f, 0f), Quaternion.identity);
        RequestInterstitial();
        MusicPlayer.instance.PlayGameMusic();
        highScoreNum = PlayerPrefs.GetInt("Highscore");
        highScore.text = highScoreNum.ToString();
    }

    void Update()
    {
        if (gameOver) 
        {
            if (scoreNum > highScoreNum)
            {
                PlayerPrefs.SetInt("Highscore", scoreNum);
                highScoreNum = PlayerPrefs.GetInt("Highscore");
                highScore.text = highScoreNum.ToString();
            }
            losingUI.SetActive(true);
            RectTransform rectTrans = scoreText.GetComponent<RectTransform>();
            rectTrans.anchorMin = new Vector2(0.5f,0.5f);
            rectTrans.anchorMax = new Vector2(0.5f,0.5f);
            rectTrans.pivot = new Vector2(0.5f,0.5f);
            rectTrans.anchoredPosition = new Vector2(-60, 80);
        }
    }

    public void Scored()
    {
        if (gameOver)
        {
            return;
        }
        scoreNum++;
        score.text = scoreNum.ToString();
    }

    public void RestartGame()
    {
        MusicPlayer.instance.PlayClick();
        if (this.interstitial.IsLoaded() && AdTimer.instance.showAd) {
            this.interstitial.Show();
        }
        else
        {
            interstitial.Destroy();
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        }
    }

    public void BackToMainMenu()
    {
        MusicPlayer.instance.PlayClick();
        MusicPlayer.instance.PlayMainMenuMusic();
        SceneManager.LoadScene("StartMenu");
    }

    private void RequestInterstitial()
    {
        // Google test interstitial ad unit ID. Replace with your own before release.
        // https://developers.google.com/admob/unity/test-ads
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";

        Debug.Log(adUnitId);
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
        MusicPlayer.instance.MuteForAd();
    }   

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        interstitial.Destroy();
        AdTimer.instance.timeBeforeNextAd = 10f;
        AdTimer.instance.showAd = false;
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {   
        print("Interstitial failed to load: " + args.ToString());
        // Handle the ad failed to load event.
    }
}
