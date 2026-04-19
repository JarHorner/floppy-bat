using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class MoblieAds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        List<string> deviceIds = new List<string>();
        deviceIds.Add("1E059813DFE8A5ADAEFF8153D55D0059");
        RequestConfiguration requestConfiguration = new RequestConfiguration
        .Builder()
        .SetTestDeviceIds(deviceIds)
        .build();

        MobileAds.SetRequestConfiguration(requestConfiguration);
    }
}
