using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRAbrirPuertas : MonoBehaviour
{
    /*Este script se encarga de disparar la animación de puertas 
     * en el mapa de VR (mapaCompletoVR) según el valor de la variable
     * puertaAbiertaa, el cual está dado por la variable "abierta" de 
     * la clase IniciarBoton, la cual envía dicho valor a través de la 
     * red con una función RPC
     */
    private Animator animadorPuerta;
    //Boton de abrir puertas de AR. 
    //Cada puerta del mapa de VR tiene un botón de AR asignado y cada botón de AR asignado tiene una puerta VR asignada. 
    public GameObject controlador;
    public bool puertaAbiertaa;
    void Start()
    {
        animadorPuerta = GetComponent<Animator>();
    }

    public void empezarAnimacion()
    {
        //puertaAbiertaa es igual al valor de la variable abierta en IniciarBoton
        puertaAbiertaa = controlador.GetComponent<IniciarBoton>().abierta;
        if (puertaAbiertaa)
        {
            Debug.Log("A ver que funcionó el RPC" + puertaAbiertaa);
            animadorPuerta.SetBool("puertaAbierta", true);
            animadorPuerta.SetBool("puertaCerrada", false);
            puertaAbiertaa = true;
        }
        else if (puertaAbiertaa == false)
        {
            Debug.Log("A ver que funcionó el RPC" + puertaAbiertaa);
            animadorPuerta.SetBool("puertaAbierta", false);
            animadorPuerta.SetBool("puertaCerrada", true);
            puertaAbiertaa = false;
        }
    }
}
