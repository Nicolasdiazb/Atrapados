using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.IO;

public class AdministradorTutorial : MonoBehaviourPunCallbacks
{
    /* Este script se encarga de enviar a 
     * los jugadores a la escena de juego (EscenaAR).
     * Está dentro del objeto CuartoActualCanvas.
     */


    //Botón de jugar
    public GameObject continuarBoton;
    public static AdministradorTutorial AT;
    //Escena a cargar
    public int multiplayScene;
    public  int personajeElegido;

    public void Awake()
    {
        personajeElegido = InfoJugador.IJ.personajeSeleccionado;
        Debug.Log("PERSONAJE: ");
        Debug.Log(personajeElegido);
    }
    public override void OnEnable()
    {
        //Si el jugador es un LocalPlayer (lo contrario a MasterClient), entonces el botón Jugar no aparece.

        if (!PhotonNetwork.IsMasterClient)
        {
            continuarBoton.SetActive(false);

        }
        else if(PhotonNetwork.IsMasterClient)
        {
            continuarBoton.SetActive(true);
        }
    }


    /* Si el jugador es el MasterClient (creador del cuarto)
     * entonces se carga la EscenaAR (multiplayScene).
     * Este script está en el OnClick del boton Jugar.
     */
    public void EmpezarJuego()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            //Cargar escena 
            PhotonNetwork.LoadLevel(multiplayScene);
        }
    }
}

//IR AL SCRIPT DE 

