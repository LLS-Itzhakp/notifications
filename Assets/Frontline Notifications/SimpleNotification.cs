using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Messaging;
using UnityEngine;

public class SimpleNotification : MonoBehaviour
{
  public FirebaseApp app;
  
    // Start is called before the first frame update
    void Start()
    {
      
      Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
      Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;
      
      
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
          var dependencyStatus = task.Result;
          if (dependencyStatus == Firebase.DependencyStatus.Available) {
            // Create and hold a reference to your FirebaseApp,
            // where app is a Firebase.FirebaseApp property of your application class.
               app = Firebase.FirebaseApp.DefaultInstance;
               Firebase.Messaging.FirebaseMessaging.SubscribeAsync("tester1");

            // Set a flag here to indicate whether Firebase is ready to use by your app.
          } else {
            UnityEngine.Debug.LogError(System.String.Format(
              "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            // Firebase Unity SDK is not safe to use here.
          }
        });
        
        


    }

    public void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token) {
      UnityEngine.Debug.Log("Received Registration Token: " + token.Token);
      

    }

    public void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e) {
      UnityEngine.Debug.Log("Received a new message from: " + e.Message.From);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
