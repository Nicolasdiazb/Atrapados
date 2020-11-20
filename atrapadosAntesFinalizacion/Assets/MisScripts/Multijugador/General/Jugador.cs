using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class Jugador : MonoBehaviour
{
    /** Este script se ejecuta en ESCENA AR 
     * Su función es ubicar a los prefabs de cada jugador en una posición
     * específica dependiendo del rol que tengan. El rol es asignado 
     * en el script "Configuración". Dicho script recibe el dato
     * de qué jugador se ha elegido del script "ConfiguracionAvatar".
     * De igual forma, basándose en dicho dato asigna los roles  de
     * "VRPlayer", "PCPlayer" o "ARPlayer". 
    */
    //Elemento necesario para mostrar objeto multijugador
    public PhotonView PV;
    public GameObject avatarJugador;
    private string nombreJugador;
    //Elementos AR
    private GameObject padreMapa;
    public GameObject arCamera;
    //Elementos VR
    public GameObject vrCamera;
    public GameObject xramanager;
    public GameObject xrrig;
    private GameObject padreVR;
    public GameObject mapaVR;
    //Elementos PC 
    public GameObject pcCamera;
    public Canvas canvasHUD;

    void Start()
    {
        //Mapa de AR, mapaCompleto
        padreMapa = GameObject.FindWithTag("mapa");
        //Objeto CamPC
        pcCamera = GameObject.FindWithTag("camPC");
        //Objeto AR Session Origin
        arCamera = GameObject.FindWithTag("camAR");
        //Objeto BotonesPC
        canvasHUD = GameObject.FindWithTag("HUD").GetComponent<Canvas>();
        //Objeto camVR (XRRig/CameraOffset)
        vrCamera = GameObject.Find("camVR");
        //Objeto XRManager
        xramanager = GameObject.FindWithTag("xrmanager");
        //Objeto XRRig 
        xrrig = GameObject.FindWithTag("xrrig");
        //Objeto Camer Offset
        padreVR = GameObject.Find("Camera Offset");
        //PhotonView 
        PV = GetComponent<PhotonView>();
        mapaVR = GameObject.FindWithTag("mapaVR");

        //Si el componente Photon View es de este cliente y se puede correr aquí
        if (PV.IsMine)
        {
            //RPC para obtener el rol de todos los jugadores 
            PV.RPC("RPC_ObtenerRol", RpcTarget.AllBuffered);
        }
    }

    void Update()
    {
    //Siempre que aún no se haya instanciado el modelo y que el jugador tenga un rol
    //se podrá instanciar un modelo 
        if (avatarJugador == null && nombreJugador != "")
        {
            /*NOTA IMPORTANTE: 
             * 'PlayerAvatar' no corresponde directamente al modelo 
             * de cada jugador. Dicho prefab se encuentra en la
             * carpeta de Resources/PhotonPrefabs de Photon
             * y tiene anclado el script "ConfiguracionAvatar" 
             *ese script es el que posiciona el modelo elegido
             * detro de "PlayerAvatar".
             */
            //Si el jugador es AR se posiciona el modelo en el SpawnPoint1
            if(nombreJugador == "ARPlayer")
            {
                if(PV.IsMine)
                {
                    Debug.Log("SoyAR");
                    avatarJugador = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerAvatar"), Configuracion.CJ.spawnPoints[0].position, Configuracion.CJ.spawnPoints[0].rotation, 0);
                    arCamera.SetActive(true);
                    //Se desactiva la función de mover
                    //avatarJugador.GetComponent<MoverJugadores>().enabled = false;
                    canvasHUD.enabled = true;
                }
            }
            //Si el jugador es PC se posiciona el modelo en el SpawnPoint2
            else if (nombreJugador == "PCPlayer")
            {
                if (PV.IsMine)
                {
                    Debug.Log("SoyPC");
                   avatarJugador = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerAvatar"), Configuracion.CJ.spawnPoints[1].position, Configuracion.CJ.spawnPoints[1].rotation, 0);
                    //Se activa los elementos de PC
                    pcCamera.GetComponent<Camera>().enabled = true;
                    //Se desactiva la función de mover
                    //avatarJugador.GetComponent<MoverJugadores>().enabled = false;
                    pcCamera.transform.SetParent(avatarJugador.transform);
                    canvasHUD.enabled = false;
                }
            }
            //Si el jugador es VR se posiciona el modelo en el SpawnPoint3
            else if (nombreJugador == "VRPlayer")
            {
                if (PV.IsMine)
                {
                    Debug.Log("SoyVR");
                    avatarJugador = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerAvatar"), Configuracion.CJ.spawnPoints[2].position, Configuracion.CJ.spawnPoints[2].rotation, 0);
                    avatarJugador.transform.SetParent(padreVR.transform);
                  
                    //Se activan los elementos de VR
                    vrCamera.GetComponent<Camera>().enabled = true;
                    vrCamera.transform.SetParent(avatarJugador.transform);     
                    //avatarJugador.GetComponent<MoverJugadores>().enabled = true;
                    canvasHUD.enabled = false;
                }
            }
        }
    }

    //Métodos RPC
    [PunRPC]
    /*Este método solicita los roles de los jugadores
      los cuales se almacenan y actualizan en el
      script de "Configuración"
         */
    void RPC_ObtenerRol()
    {
        Debug.Log("Obteniendo");
        nombreJugador = Configuracion.CJ.rolJugador;
        Configuracion.CJ.ActualizarRoles();
        Debug.Log(nombreJugador);
        //Una vez se tiene el rol de todos los jugadores
        //se solicita el valor de nuevo para ser utilizado en este script
        PV.RPC("RPC_EnviarRol", RpcTarget.OthersBuffered, nombreJugador);
    }

    [PunRPC]
    void RPC_EnviarRol(string rol)
    {
        //el el rol de cada jugador queda guardado en nombreJugador
        nombreJugador = rol;
        Debug.Log("Enviando" + rol);
    }
}
//Para entender la conexión multijugador entre puertas ir al script PrenderLuz.cs 
//Para entender la visualización de VR en AR ir al Script MoverJugadores.cs