//Para utilizar elementos de Photon
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Se utilizar el MonoBehaviourPunCallbacks para utilizar las callbacks de Photon
public class TestConexion : MonoBehaviourPunCallbacks
{
    void Start()
    {
        Debug.Log("Conectándose al servidor");
        //Limita al jugador a una versión determinada del juego
        PhotonNetwork.GameVersion = "0.0.0";
        //Se conecta al servidor usando la configuración por defecto
        PhotonNetwork.ConnectUsingSettings();
    }

    //Revisar documentación https://doc-api.photonengine.com/en/pun/v2/interface_photon_1_1_realtime_1_1_i_connection_callbacks.html
    /*override de una callback Método para verificar la conexión.
     * Una vez nos hemos conectado al master, se llama a la función
     * JoinLobby() para unirnos a un Lobby (paso previo para unirse a un cuarto)
     */

    public override void OnConnectedToMaster()
    {
        Debug.Log("Nos hemos conectado");
        PhotonNetwork.JoinLobby();
    }
    //Método en caso de que la conexión falle. 
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Nos hemos desconectado del servidor. ¿Qué pasó? :c"+ cause.ToString(), this);
    }
    //Método para verificar que nos unimos a un Lobby. 
    public override void OnJoinedLobby()
    {
        Debug.Log("Ya estamos en el Lobby");
    }

    //IR AL SCRIPT "CrearCuarto.cs"
}
