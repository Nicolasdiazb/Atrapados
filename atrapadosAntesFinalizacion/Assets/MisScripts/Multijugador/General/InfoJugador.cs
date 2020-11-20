using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoJugador : MonoBehaviour
{
    /* Este script se encarga de almacenar los prefabs 
     * correspondientes a cada jugador dentro de un arreglo.
     * Se encuentra dentro del objeto InfoJugador.
     */
    // Singleton
    public static InfoJugador IJ;
    public int personajeSeleccionado;
    //Modelos de los personajes. Están en la carpeta de Prefabs de proyecto
    public GameObject[] personajes;


    private void OnEnable()
    {
        if(InfoJugador.IJ == null)
        {
            InfoJugador.IJ = this;
        }
        else 
        {
           if (InfoJugador.IJ != this)
           {
                Destroy(InfoJugador.IJ.gameObject);
                InfoJugador.IJ = this;
            }
            
        }
    }

    void Start()
    {
        /*Función de Unity que guarda preferencias de personajes
        * "Si se guarda una preferencia de "MiPersonaje", el int 
        * se le asigna a la variable personajeSeleccionado 
        */
        if(PlayerPrefs.HasKey("MiPersonaje"))
        {
            personajeSeleccionado = PlayerPrefs.GetInt("MiPersonaje");

        }
        //Si no se define un personaje, por defecto será el personaje 0 (Laura)
        else
        {
            personajeSeleccionado = 0;
            PlayerPrefs.SetInt("MiPersonaje", personajeSeleccionado);
        }
    }

    
}
// IR AL SCRIPT Configuracion.cs (se encuentra en el objeto GameSetup de la EscenaAR)