using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PluginWrapper : MonoBehaviour
{
    private AndroidJavaObject javaClass;
    private int playerID;

    // Start is called before the first frame update
    void Start()
    {
        javaClass = new AndroidJavaObject("paquete.nombre de la clase");
        playerID = javaClass.Call<int>("funcion");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
