using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class Jugador
{
    public int ataque;
    public int defensa;
    public int experiencia;
    public int oro;
    public int velocidad;
    public int vida;

    public Jugador(int ataque, int defensa, int experiencia, int oro, int velocidad, int vida)
    {
        this.ataque = ataque;
        this.defensa = defensa;
        this.experiencia = experiencia;
        this.oro = oro;
        this.velocidad = velocidad;
        this.vida = vida;
    }

    public Jugador()
    {
        // Empty method
    }
}
