using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.IO;

public class AdministradorCanvasJugadores : MonoBehaviourPunCallbacks
{
    /* Este script se encarga de enviar a 
     * los jugadores a la escena de juego (EscenaAR).
     * Está dentro del objeto CuartoActualCanvas.
     */

     //Script de AdministradorJugadores. 
    [SerializeField]
    private AdministradorJugadores _administradorJugadores;
    //Listado de todos los jugadores
    private List<AdministradorJugadores> _listados = new List<AdministradorJugadores>();

    private bool _listo = false;

    //Botón de jugar
    public GameObject jugar;

    //Escena a cargar
    public int multiplayScene;
    private void Awake()
    {
        ObtenerJugadores();
    }

    public override void OnEnable()
    {
        //Si el jugador es un LocalPlayer (lo contrario a MasterClient), entonces el botón Jugar no aparece.
        if (!PhotonNetwork.IsMasterClient)
        {
            jugar.SetActive(false);
        }
    }


    //Por cada jugador en el cuarto actual, se obtiene su información y 
    //se enlista 
    private void ObtenerJugadores()
    {
        foreach(KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }

    private void AddPlayerListing(Player player)
    {
        AdministradorJugadores listado = Instantiate(_administradorJugadores);
        if (listado != null)
        {
            listado.SetPlayerInfo(player);
            _listados.Add(listado);
        }
    }
    //Si un jugador entra al cuarto se agrega en el listado de jugadores 
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }
  

    /* Si el jugador es el MasterClient (creador del cuarto)
     * entonces se carga la EscenaAR (multiplayScene).
     * Este script está en el OnClick del boton Jugar.
     */
    public void EmpezarJuego()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            //Se asegura de que solo el MasterClient pueda iniciar el juego
            for (int i = 0; i < _listados.Count; i++)
            {
                if (_listados[i].Jugador != PhotonNetwork.LocalPlayer)
                {
                    if (!_listados[i].Listo)
                    {
                        return;
                    }
                }     
            }
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.CurrentRoom.IsOpen = true;
            PhotonNetwork.CurrentRoom.IsVisible = true;
            //Cargar escena 
            PhotonNetwork.LoadLevel(multiplayScene);
            
        }
    }
}

//IR AL SCRIPT DE AdministradorJugadores.cs (Carpeta de Prefabs, ListadoJugadores)

