using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPC : MonoBehaviour
{
    /* Este script se encarga de almacenar los prefabs 
     * correspondientes a cada jugador dentro de un arreglo.
     * Se encuentra dentro del objeto InfoJugador.
     */
    // Singleton
    public static InfoPC IP;
    public int pcDentro;
    //Modelos de los personajes. Están en la carpeta de Prefabs de proyecto
    public GameObject[] personaje;

    private void OnEnable()
    {
        if (InfoPC.IP == null)
        {
            InfoPC.IP = this;
        }
        else
        {
            if (InfoPC.IP != this)
            {
                Destroy(InfoPC.IP.gameObject);
                InfoPC.IP = this;
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
            pcDentro = PlayerPrefs.GetInt("Estado");

        }
        //Si no se define, 0 falso
        else
        {
            pcDentro = 0;
            PlayerPrefs.SetInt("Estado", pcDentro);
        }
    }
}
// IR AL SCRIPT Configuracion.cs (se encuentr