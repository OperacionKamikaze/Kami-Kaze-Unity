using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIHealthBarEnemy : MonoBehaviour
{
    public Image healthbar;

    public enemyController enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = enemy.currentLife / enemy.maxLife;
    }
}
