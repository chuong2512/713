using System;
using UnityEngine;

//using UnityEngine.Advertisements;
// Example script showing how to invoke the Google Mobile Ads Unity plugin.
public class Adcontrol : MonoBehaviour
{
    public static Adcontrol instance;


    private float deltaTime = 0.0f;
    private static string outputMessage = string.Empty;
    public string AppID = "ca-app-pub-3940256099942544~3347511713";
    public string BannerID = "ca-app-pub-3940256099942544/6300978111";

    public string InterstitialID = "ca-app-pub-3940256099942544/1033173712";
//
//	[Header("Adcolony")]
//	public bool Adcolony;
//
//	[Header("Chartboost")]
//	public bool Chartboost;


    public static string OutputMessage
    {
        set { outputMessage = value; }
    }

    public void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void Start()
    {
        DontDestroyOnLoad(gameObject);

        RequestInterstitial();
        RequestBanner();

        ShowInterstitial();
    }

    public void Update()
    {
        // Calculate simple moving average for time to render screen. 0.1 factor used as smoothing
        // value.
        this.deltaTime += (Time.deltaTime - this.deltaTime) * 0.1f;
    }


    // Returns an ad request with custom ad targeting

    public void RequestBanner()
    {
    }

    public void RequestInterstitial()
    {
    }


    public void ShowInterstitial()
    {
    }

    public void ShowRewardBasedVideo()
    {
    }
}