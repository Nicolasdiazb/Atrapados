using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CrearCuarto : MonoBehaviourPunCallbacks
{
    /* Este script se encarga de crear cuartos 
     * para que los jugadores puedan acceder a ellos. 
     * Está dentro del Botón "CrearCuarto"
     * 
     * En este programa el cuarto empieza a visualizarse 
     * desde el canvas de selección
     * de jugador. 
     * 
     * En caso de querer entender cómo unirse a un cuarto
     * ya existente vaya al script UnirCuarto.cs
     */

    //Referencia al Canvas que almacena el canvas de crear cuarto y seleccionar jugador
    private CanvasCuarto _canvasCuarto;
   
    public void InicializarPrimero(CanvasCuarto doscanvas)
    {
        _canvasCuarto = doscanvas;
    }
    //Se asigna al valor del input "CuartoACrear"
    [SerializeField]
    private Text _nombreCuarto;

    //Método para crear cuarto. Está en OnClick del botón CrearCuarto.
     
    public void crearCuarto()
    {
        //Si no estamos conectados, no permite avanzar
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }
        //RoomOptions permite definir valores necesarios para crear un cuarto
        RoomOptions configuracionCuarto = new RoomOptions();
        //Cantidad máxima de jugadores
        configuracionCuarto.MaxPlayers = 3;
        /*Se crea un cuarto on la configuración especificada y
         * se le asigna el nombre que el usuario digita 
         * en el input de crear cuarto */
        PhotonNetwork.CreateRoom(_nombreCuarto.text, configuracionCuarto, TypedLobby.Default);
    }
    //Verifica si se creó el cuarto
    public override void OnCreatedRoom()
    {
        Debug.Log("Se ha creado el cuarto");
        //Si el cuarto se creó se muestra el canvas perteneciente al cuarto actual. 
        _canvasCuarto.CuartoActualCanvas.Mostrar();
        
    }
    //En caso de que la creación del cuarto falle, se envía un mensaje con el fallo. 
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("La creación del cuarto ha fallado " + message, this);
    }

    public override void OnConnectedToMaster()
    {
        //Sincroniza la escena que carga
        PhotonNetwork.AutomaticallySyncScene = true;
       
    }

    // IR AL SCRIPT CuartoActualCanvas.cs

}
