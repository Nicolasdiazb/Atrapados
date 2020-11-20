using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCont : MonoBehaviour
{
    /* Este script se encarga de almacenar el personaje
     * seleccionado por el usuario. Está en el OnClick de
     * ElegirLaura (0), ElegirHector (1) y ElegirJulian (2) 
     */
    public void ElegirPersonaje(int personaje)
    {
        if (InfoJugador.IJ != null)
        {
            InfoJugador.IJ.personajeSeleccionado = personaje;
            //Selección de personaje (revisar Start en InfoJugador.cs)
            PlayerPrefs.SetInt("MiPersonaje", personaje);
            Debug.Log("Elegí " + personaje);
        }
    }
}
// IR AL SCRIPT InfoJugador.cs
