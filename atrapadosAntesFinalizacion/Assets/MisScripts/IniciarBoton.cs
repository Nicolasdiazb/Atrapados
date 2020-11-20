using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class IniciarBoton : MonoBehaviour
{
    public static IniciarBoton BotonesAR;
    [SerializeField]
    // Arreglo de puertas con el script PuertasUbicadas
    private BotonesPuertaUbicados[] botonesPUbicadas;
    [SerializeField]
    // Arreglo de puertas con el script PuertasUbicadas
    private BotonesDuctosUbicados[] botonesDUbicados;
    //Script para llamar animación con botón 
    bool botonPresionado = false;
    //Guardar objetos y animators

    public AudioSource fuenteSonido;
    public AudioClip puertaS;
    public AudioClip ductoS;
    /// public GameObject obj;
    public static string mensaje;

    public Color32 colorAbrir = new Color32(57, 255, 110, 1);
    public Color colorOriginal = new Color(0.15F, 0.69F, 0.53F);
    public Color32 colorMorado = new Color32(194, 46, 255, 1);
    public Color32 colorNaranja = new Color32(254, 161, 0, 1);


    //Variables interacción PC y AR (puertas)
    public GameObject miLuz;
    private bool encendido;
    //Variables interacción AR y VR (puertas)
    public GameObject miPuerta;
    public bool abierta;


    private PhotonView PhotonV;
    void Start()
    {
        PhotonV = GetComponent<PhotonView>();
    }

    private void OnEnable()
    {
        if (IniciarBoton.BotonesAR == null)
        {
            IniciarBoton BotonesAR = this;
        }
        else
        {
            if (IniciarBoton.BotonesAR != this)
            {
                Destroy(IniciarBoton.BotonesAR.gameObject);
                IniciarBoton.BotonesAR = this;
            }

        }
    }
    public void ActivarNuevoP()
    {
        Debug.Log("miau1");
        BotonesPuertaUbicados botonesPUbicadas = gameObject.GetComponent<BotonesPuertaUbicados>();
        BotonesDuctosUbicados botonesDUbicadas = gameObject.GetComponent<BotonesDuctosUbicados>();
        if (botonesPUbicadas != null)
        {
            empezarAnimacionPuerta(botonesPUbicadas);
        }
        else if (botonesDUbicadas != null)
        {
            empezarAnimacionDucto(botonesDUbicadas);
        }

    }
    void empezarAnimacionPuerta(BotonesPuertaUbicados seleccionado)
    {
        foreach (BotonesPuertaUbicados a in botonesPUbicadas)
        {
            //Recibe la variable hayLuz del objeto miLuz (Botón del canvas BotonesPC)
            encendido = miLuz.GetComponent<luzRay>().hayLuz;
            GameObject puertaa = a.GetComponent<BotonesPuertaUbicados>().puertaAsignada;
            Animator animadorPuerta = puertaa.GetComponent<Animator>();
            Debug.Log("Estoy en foraech");
            if (seleccionado == a)
            {
                /*Si la variable hayLuz del objeto miLuz es true y se 
                * está presionando el botón por primera vez se dispara la animación
                * de abrir puerta de AR. */
                if (botonPresionado == false && encendido == true)
                {
                    animadorPuerta.SetBool("puertaAbierta", true);
                    animadorPuerta.SetBool("puertaCerrada", false);
                    fuenteSonido.PlayOneShot(puertaS);
                    botonPresionado = true;
                    Debug.Log("Llegue a abrir");
                    //Esta variable actúa como un disparador de animación en VR
                    abierta = true;
                   
                }
                /*Si la variable hayLuz del objeto miLuz es true y se 
                * está presionando el botón por segunda vez se dispara la animación
                * de cerrar puerta de AR. */
                else if (botonPresionado == true && encendido == true)
                {
                    //Condicion para cerrar
                    animadorPuerta.SetBool("puertaAbierta", false);
                    animadorPuerta.SetBool("puertaCerrada", true);
                    botonPresionado = false;
                    Debug.Log("Llegue a cerrar");
                    //Esta variable actúa como un disparador de animación en VR
                    abierta = false;
                    
                }
                a.IsSelected = true;
                //Se envía el valor de la variable "abierta" a todos los jugadores. 
                PhotonV.RPC("RPC_enviarValorPuerta", RpcTarget.All, abierta);

            }
            else
            {
                a.IsSelected = false;
            }

        }
    }


    void empezarAnimacionDucto(BotonesDuctosUbicados seleccionado)
    {
        foreach (BotonesDuctosUbicados a in botonesDUbicados)
        {

            GameObject ducto = a.GetComponent<BotonesDuctosUbicados>().ductoAsignado;
            Animator animadorDucto = ducto.GetComponent<Animator>();
            Debug.Log("Estoy en foraech");
            if (seleccionado == a)
            {
                if (botonPresionado == false)
                {
                    animadorDucto.SetBool("estaAbierta", true);
                    animadorDucto.SetBool("estaCerrada", false);
                    fuenteSonido.PlayOneShot(ductoS);
                    botonPresionado = true;
                    Debug.Log("Llegue a abrir ducto");
                }
                else
                {
                    //Condicion para cerrar
                    animadorDucto.SetBool("estaAbierta", false);
                    animadorDucto.SetBool("estaCerrada", true);
                    botonPresionado = false;
                    Debug.Log("Llegue a cerrar ducto");
                }
                a.IsSelected = true;
            }
            else
            {
                a.IsSelected = false;
            }

        }

    }

    /* Se envía el valor de "abierta" a través de la red
     * y posteriormente se llama al método empezarAnimacion(), 
     * perteneciente a la clase VRAbrirPuertas, la cual utiliza
     * la variable "abierta". 
     */
    [PunRPC]
    void RPC_enviarValorPuerta(bool valorPuerta)
    {
        abierta = valorPuerta;
       
        Debug.Log("Puerta Rpc " + valorPuerta);
        miPuerta.GetComponent<VRAbrirPuertas>().empezarAnimacion();
    }
}
//IR A SCRIPT VRAbrirPuertas.cs



