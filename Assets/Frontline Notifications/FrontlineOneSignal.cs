using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OneSignalSDK;

public class FrontlineOneSignal : MonoBehaviour
{

    
    /// <summary>
    /// The unique identifier for your application from the OneSignal dashboard
    /// https://documentation.onesignal.com/docs/accounts-and-keys#app-id
    /// </summary>
    public static string AppId = "73deabe2-9888-40e4-ac05-2c9eda5ea0fd";

 
    /// <summary>
    /// Allows you to delay the initialization of the SDK until <see cref="OneSignal.PrivacyConsent"/> is set to
    /// true. Must be set before <see cref="OneSignal.Initialize"/> is called.
    /// </summary>
    public bool RequireUserConsent = false;

    /// <summary>
    /// Disable or enable location collection by OneSignal (defaults to enabled if your app has location permission).
    /// </summary>
    /// <remarks>This method must be called before <see cref="OneSignal.Initialize"/> on iOS.</remarks>
    public bool ShareLocation = false;

    private void Start() {
        OneSignal.Initialize(AppId);
        
        OneSignal.User.AddTag("Mail", "itzhak@lls-ltd.com");
        
        OneSignal.Notifications.Clicked += (sender, e) =>
        {
            // Access the notification with e.Notification and the click result with e.Result
            
            Debug.Log($"Notification Clicked - {e.Notification.Title}");
        };
    }

 

    // Update is called once per frame
    void Update()
    {
        
    }
}
