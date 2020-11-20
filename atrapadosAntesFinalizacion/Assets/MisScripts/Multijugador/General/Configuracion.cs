using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class Configuracion : MonoBehaviour
{

    /* Este script se encarga de almancenar la ubicación en la
     * que se instanciarán los jugadores (spawnPoints), además de
     * asignar roles dependiendo del personaje seleccionado. Se encuentra
     * dentro del objeto GameSetup. 
     */

    // Se hace un Singleton de la clase para poder utilizar todos su componentes en otros scripts
    public static Configuracion CJ;
    //Almacena los 3 SpawnPoint, cada uno para un jugador distinto
    public Transform[] spawnPoints;
    public string rolJugador;
    public bool instanciarVR;

    private void OnEnable()
    {

        if (Configuracion.CJ == null)
        {
           
            Configuracion.CJ = this;
            /*NOTA IMPORTANTE:
             Se instancia el objeto PhotonNetworkPlayer, ubicado en la carpeta
             "Resources/PhotonPrefabs de Photon. Este tiene anclado el script
             "Jugador.cs", el cual se encarga de intanciar el objeto "PlayerAvatar", quien 
              a su vez recibe el dato de qué modelo debe instanciar"
             */
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonNetworkPlayer"), Configuracion.CJ.spawnPoints[0].position, Configuracion.CJ.spawnPoints[0].rotation, 0);
            /*Se inicializa el rol del jugador dependiendo de lo escogido por el usuario.
             * Para obtener dicho dato se llama al singleton InfoJugador*/
            if (InfoJugador.IJ.personajeSeleccionado == 0)
            {
                Debug.Log("Inicio VR:");
                rolJugador = "VRPlayer";
            }
            else if (InfoJugador.IJ.personajeSeleccionado == 1)
            {
                Debug.Log("Inicio VR:");
                Debug.Log("Inicio PC:");
                rolJugador = "PCPlayer";
            }
            else if (InfoJugador.IJ.personajeSeleccionado == 2)
            {
                Debug.Log("Inicio AR");
                rolJugador = "ARPlayer";
            }

        }


    }

    /* Este método se encarga de confirmar los roles de los jugadores.
     * Se llama desde el RPC_ObtenerRol de la clase jugador*/
    public void ActualizarRoles()
    {
        if (InfoJugador.IJ.personajeSeleccionado == 0)
        {
            Debug.Log("Actualización VR:");
            rolJugador = "VRPlayer";
        }
        else if (InfoJugador.IJ.personajeSeleccionado == 1)
        {
            Debug.Log("Actualización PC:");
            rolJugador = "PCPlayer";
        }
        else if (InfoJugador.IJ.personajeSeleccionado == 2)
        {
            Debug.Log("Actualización AR");
            rolJugador = "ARPlayer";
        }
    }


}
//IR AL SCRIPT ConfiguracionAvatar.cs
//(se encuentra en el objeto PlayerAvatar dentro de Photon/PhotonUnityNetworking/Resources/PhotonPrefabs
