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

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = (player.currentLife / player.maxLife);
        if (player.currentLife <= 0)
        {
            winText.text = "YOU LOOSE";
        }
    }
}
