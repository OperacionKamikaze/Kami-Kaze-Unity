using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Firebase.Database;

public class UIHealthBarEnemy : MonoBehaviour
{
    public Image healthbar;

    public enemyController enemy;

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
        healthbar.fillAmount = enemy.currentLife / enemy.maxLife;
        if (enemy.currentLife <= 0)
        {
            winText.text = "YOU WIN";
            reference.Child("users").Child(username.text).Child("ultimaBatalla").SetValueAsync(true).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Application.Quit();
                }
            });
        }
    }
}
