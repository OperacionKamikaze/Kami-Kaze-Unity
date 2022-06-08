using Firebase.Analytics;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBaseInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
            DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        });
    }
}
