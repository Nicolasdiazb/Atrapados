using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoVR : MonoBehaviour
{
    /* Este script se encarga de almacenar los prefabs 
     * correspondientes a cada jugador dentro de un arreglo.
     * Se encuentra dentro del objeto InfoJugador.
     */
    // Singleton
    public static InfoVR IV;
    public int vrDentro;
    //Modelos de los personajes. Están en la carpeta de Prefabs de proyecto
    public GameObject[] personaje;

    private void OnEnable()
    {
        if (InfoVR.IV == null)
        {
            InfoVR.IV = this;
        }
        else
        {
            if (InfoVR.IV != this)
            {
                Destroy(InfoVR.IV.gameObject);
                InfoVR.IV = this;
            }

        }
    }

    void Start()
    {
        /*Función de Unity que guarda preferencias de personajes
        * "Si se guarda una preferencia de "MiPersonaje", el int 
        * se le asigna a la variable personajeSeleccionado 
        */
        if (PlayerPrefs.HasKey("Estado"))
        {
            vrDentro = PlayerPrefs.GetInt("Estado");

        }
        //Si no se define, 0 falso
        else
        {
            vrDentro = 0;
            PlayerPrefs.SetInt("Estado", vrDentro);
        }
    }
}
// IR AL SCRIPT Configuracion.cs (se encuentr