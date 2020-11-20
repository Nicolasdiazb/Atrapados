using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
public class AdministradorJugadores : MonoBehaviour
{
    /* Este script se encarga de establecer al información
     * de todo jugador que ingrese a un cuarto.
     * Se encuentra dentro del objeto ListadoJugadores ubicado
     * en la carpeta de Prefabs
     */
    public Player Jugador { get; private set; }
    public bool Listo = false;
    public void SetPlayerInfo(Player jugador)
    {
        Jugador = jugador;
        //Crea un jugador con un nombre random y lo establece en la propiedad Nickname de Photon. 
        jugador.NickName = "Jugador" + Random.Range(0, 1000000);
        Debug.Log(jugador.NickName);
    }
}

//IR AL SCRIPT MenuCont.cs 
