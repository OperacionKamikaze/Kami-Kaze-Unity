using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Firebase.Database;

public class UIHealthBarPlayer : MonoBehaviour
{
    public Image healthbar;

    public PlayerMovement player;

    public Text winText;

    DatabaseReference reference;

    public Text username;

    // Start is called before the first frame update
    void Start()
    {
        FirebaseDatabase database = FirebaseDatabase.DefaultInstance;
        reference = database.RootReference;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = (player.currentLife / player.maxLife);
        if (player.currentLife <= 0)
        {
            winText.text = "YOU LOOSE";
            reference.Child("users").Child(username.text).Child("ultimaBatalla").SetValueAsync(false).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Application.Quit();
                }
            });
        }
    }
}
