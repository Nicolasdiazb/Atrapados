using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class UnirCuarto : MonoBehaviourPunCallbacks
{
    /*Este script se encarga de acceder a cuartos existentes. 
     * Está dentro del Botón "UnirseCuarto"
     * 
     * En caso de querer entender cómo crear un cuarto
     * desde cero vaya al script CrearCuarto.cs
     */

    //Referencia al Canvas que almacena el canvas de crear cuarto y seleccionar jugador
    private CanvasCuarto _canvasCuarto;

    //Se asigna al valor del input "CuartoAUnirse"
    [SerializeField]
    private Text _nombreCuarto;


    public void InicializarPrimero(CanvasCuarto doscanvas)
    {
        _canvasCuarto = doscanvas;
    }


    //Método para unirse a un cuarto. Está en OnClick del botón UnirseCuarto.
    public void unirCuarto()
    {
        //Verifica que se haya conectado anteriormente. 
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }
        //Intenta unirse a un cuarto con el nombre asignado en el input CuartoAUnirse
        PhotonNetwork.JoinRoom(_nombreCuarto.text);
    }

    //Verifica si se pudieron unir al cuarto. 
    public override void OnJoinedRoom()
    {
        Debug.Log("Te has unido exitosamente");
        //Si se pudieron unir muestra el canvas perteneciente al cuarto actual. 
        _canvasCuarto.CuartoActualCanvas.Mostrar();
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Ha habido un error al unirse al cuarto" + message, this);
    }

    public override void OnConnectedToMaster()
    {
        //Sincroniza la escena que carga
        //PhotonNetwork.AutomaticallySyncScene = true;
        //El juego espera una acción del usuario
    }

    // IR AL SCRIPT CuartoActualCanvas.cs
}
