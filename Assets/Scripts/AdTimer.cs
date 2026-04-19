using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdTimer : MonoBehaviour
{
    public static AdTimer instance; 
    public float timeBeforeNextAd;
    public bool showAd = false;
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBeforeNextAd <= 0)
        {
            showAd = true;
        }
        else
        {
            timeBeforeNextAd -= Time.deltaTime;
        }
    }
}
