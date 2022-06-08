using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    DatabaseReference reference;

    // Start is called before the first frame update
    void Start()
    {
        FirebaseDatabase database = FirebaseDatabase.DefaultInstance;
        reference = database.RootReference;

        reference.Child("users").Child("pepito").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snap = task.Result;
                Jugador retPlay = new Jugador((int)snap.Child("ataque").Value, (int)snap.Child("defensa").Value, (int)snap.Child("experiencia").Value, (int)snap.Child("oro").Value, (int)snap.Child("velocidad").Value, (int)snap.Child("vida").Value);
                print(snap.Child("vida").Value);
                LoadScene("SampleScene");
            }
        });
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void exit()
    {
        Application.Quit();
    }
}
