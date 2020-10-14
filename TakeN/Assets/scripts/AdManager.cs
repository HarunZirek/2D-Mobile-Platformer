using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    private string playStoreID = "3658947";
    private string appStoreID = "3658946";

    private string interstitialAd = "video";
    //private string rewardedVideoAd = "rewardedVideo";
    private string reviveVideoAd = "reviveVideo";

    public bool isTargetPlayStore;
    public bool isTestAd;

    public GameObject canvas;
    private void Start()
    {
        Advertisement.AddListener(this);
        InitializeAdvertisement();
        canvas = GameObject.Find("Canvas");
    }

    private void InitializeAdvertisement()
    {
        if(isTargetPlayStore)
        {
            Advertisement.Initialize(playStoreID, isTestAd);
            return;
        }
       else if(!isTargetPlayStore)
        {
            Advertisement.Initialize(appStoreID, isTestAd);
            return;
        }
    }

    public void playInterstitialAd()
    {
        if(!Advertisement.IsReady(interstitialAd))
        {
            return;
        }
        else
        {
            Advertisement.Show(interstitialAd);
        }
    }

    public void playReviveVideoAd()
    {
       if(canvas.GetComponent<gameOverMenu>().reviveCount==1)
        {
            canvas.GetComponent<gameOverMenu>().reviveCount = 0;
            if (!Advertisement.IsReady(reviveVideoAd))
            {
                return;
            }
            else
            {
                Advertisement.Show(reviveVideoAd);
            }
           
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch(showResult)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if(placementId==reviveVideoAd)
                {
                   if(canvas!=null)
                    {
                        canvas.GetComponent<gameOverMenu>().revive();
                    }
                    return;
                }
                else if(placementId==interstitialAd)
                {                 
                    return;
                }
                break;
        }
    }
}
