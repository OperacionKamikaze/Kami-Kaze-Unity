using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DbManager : MonoBehaviour
{
    DatabaseReference reference;

    // Start is called before the first frame update
    void Start()
    {
        FirebaseDatabase database = FirebaseDatabase.GetInstance("https://kami-kaze-347314-default-rtdb.firebaseio.com/");
        reference = database.RootReference;

        retrieveData();
    }

    public void retrieveData()
    {
        FirebaseDatabase.GetInstance("https://kami-kaze-347314-default-rtdb.firebaseio.com/").GetReference("users").GetValueAsync().ContinueWithOnMainThread(
            task => {
                if (task.IsFaulted)
                {
                    // Handle the error...
                    print("Error retrieving database");
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;

                    foreach(var jugador in snapshot.Children)
                    {
                        Jugador jugadorRetornado= JsonUtility.FromJson<Jugador>(jugador.GetRawJsonValue());
                        print(jugadorRetornado.ataque);
                    }
                }
            }
        );
    }
}
