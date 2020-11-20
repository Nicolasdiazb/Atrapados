using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ConfiguracionAvatar : MonoBehaviour
{
    private PhotonView PV;
    public static int valorPersonaje;
    public GameObject miPersonaje;
    void Start()
    {
        PV = GetComponent<PhotonView>();
        //Si el componente Photon View es de este cliente y se puede correr aquí
        if (PV.IsMine)
        {
            //1)RPC para asignar un modelo al personaje seleccionado en todos los jugadores
            //según la variable personajeSeleccionado de InfoJugador, la cual es modificada
            // con el método ElegirPersonaje(int) del script MenuCont
            PV.RPC("RPC_AgregarPersonaje", RpcTarget.AllBuffered, InfoJugador.IJ.personajeSeleccionado);
            Debug.Log("Estoy en config avatar");
        }

    }

    [PunRPC]
    void RPC_AgregarPersonaje(int personaje)
    {
        //Se guarda valorPersonaje en caso de necesitarse localmente después
        valorPersonaje = personaje;
        /*NOTA IMPORTANTE:
         * Esto no instancia los modelos en la posición deseada directamente. 
         * Solo los envía a la posición que tiene "PlayerAvatar" (ubicado en la 
         * carpeta Resources/PhotonPrefab de Photon, el cual a su vez tiene
         * anclado este script, lo cual hace que guarde los datos del modelo. 
         */
        miPersonaje = Instantiate(InfoJugador.IJ.personajes[personaje], transform.position, transform.rotation, transform);
        //PV.RPC("RPC_EnviarPersonaje", RpcTarget.OthersBuffered, personaje);
        Debug.Log("Personaje Primer RPC: " + personaje);
    }

}
//IR AL SCRIPT Jugador.cs
//(se encuentra en el objeto PhotonNetworkPlayer dentro de Photon/PhotonUnityNetworking/Resources/PhotonPrefabs
