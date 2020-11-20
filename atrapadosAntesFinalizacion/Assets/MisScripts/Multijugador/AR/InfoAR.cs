using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoAR : MonoBehaviour
{
    /* Este script se encarga de almacenar los prefabs 
     * correspondientes a cada jugador dentro de un arreglo.
     * Se encuentra dentro del objeto InfoJugador.
     */
    // Singleton
    public static InfoAR IA;
    public int arDentro;
    //Modelos de los personajes. Están en la carpeta de Prefabs de proyecto
    public GameObject[] personaje;

    private void OnEnable()
    {
        if (InfoAR.IA == null)
        {
            InfoAR.IA = this;
        }
        else
        {
            if (InfoAR.IA != this)
            {
                Destroy(InfoAR.IA.gameObject);
                InfoAR.IA = this;
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
            arDentro = PlayerPrefs.GetInt("Estado");

        }
        //Si no se define, 0 falso
        else
        {
            arDentro = 0;
            PlayerPrefs.SetInt("Estado", arDentro);
        }
    }
}
// IR AL SCRIPT Configuracion.cs (se encuentr