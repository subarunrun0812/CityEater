using GoogleMobileAds.Api;
using UnityEngine;
using System.Collections.Generic;
public class GoogleMobileAdsDemoScript : MonoBehaviour
{

    public void Start()
    {
        // Initialize the Mobile Ads SDK.
        MobileAds.Initialize((initStatus) =>
        {
            // SDK initialization is complete
        });

    }
}