using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Valvula : MonoBehaviour
{
    // Start is called before the first frame update
    public bool IsSelected { get; set; }
    // public GameObject Indicador;
    public bool encendido = false;
    public GameObject Particulas;
    public AudioClip ductoS;
    public AudioSource fuenteSonido;
    //public GameObject miDucto;
    public PhotonView PhotonV;
    public Animator animadorValvula;
    public Animator animadorDucto;
    public Camera camaraPC;
    


    void Start()
    {
        print("a");
        //PhotonV = GetComponent<PhotonView>();
    }


    void Update()
    {/*


        RaycastHit hit;
        Ray ray = camaraPC.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            //Intentar encontrar el script
            // yo = hit;

            if (Input.GetMouseButtonDown(0))
            {
                //cambio();
                //detector = true;
                Debug.Log("Toque");
            }
            else
            {
                //detector = false;

            }
        }*/
    }
    public void cambio()
    {

        //Animator animadorDucto = miDucto.GetComponent<Animator>();
        if (encendido == false)
        {
            encendido = true;
            animadorDucto.SetBool("estaAbierta", true);
            animadorDucto.SetBool("estaCerrada", false);
            animadorValvula.SetBool("ValvulaOn", true);
            animadorValvula.SetBool("ValvulaOff", false);
            fuenteSonido.PlayOneShot(ductoS);
            Debug.Log("la valvula está  " + encendido);
        }
        else if (encendido == true)
        {
            encendido = false;
            animadorDucto.SetBool("estaAbierta", false);
            animadorDucto.SetBool("estaCerrada", true);
            animadorValvula.SetBool("ValvulaOff", true);
            animadorValvula.SetBool("ValvulaOn", false);
            Debug.Log("la valvula está  " + encendido);
        }
        PhotonV.RPC("RPC_encenderValvula", RpcTarget.Others, encendido);
    }

    [PunRPC]
    void RPC_encenderValvula(bool encendidoRPC)
    {
        Debug.Log("valvula on?");
        encendido = encendidoRPC;
        Debug.Log("Mi valvula está... " + encendidoRPC);
    }
}