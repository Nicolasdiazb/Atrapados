using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class newTestValvula : MonoBehaviour
{

	[SerializeField]
    private Camera camaraPC;
    public bool activado;
     public GameObject Particulas;
    public AudioClip ductoS;
    public AudioSource fuenteSonido;
    //public GameObject miDucto;
    public PhotonView PhotonV;
    public Animator animadorValvula;
    public Animator animadorDucto;
    private Collider coll;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
        activado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camaraPC.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (coll.Raycast(ray, out hit, 500.0f))
            {
                Debug.Log("estoy tocando mi valvula");
                activacion();
            }
        
    }
    muestra();
}

void activacion(){
	 if (activado == false)
        {
            activado = true;
            fuenteSonido.PlayOneShot(ductoS);
            
        }
        else if (activado == true)
        {
           activado = false;

        }
        PhotonV.RPC("RPC_encenderValvula", RpcTarget.Others, activado);
}

void muestra(){

	if (activado == true){
		Particulas.SetActive(true);
            animadorDucto.SetBool("estaAbierta", true);
            animadorDucto.SetBool("estaCerrada", false);
            animadorValvula.SetBool("ValvulaOn", true);
            animadorValvula.SetBool("ValvulaOff", false);
            
            //Debug.Log("la valvula está  " + activado);
	}
	else if (activado == false){
		 activado = false;
            Particulas.SetActive(false);
            animadorDucto.SetBool("estaAbierta", false);
            animadorDucto.SetBool("estaCerrada", true);
            animadorValvula.SetBool("ValvulaOff", true);
            animadorValvula.SetBool("ValvulaOn", false);
            //Debug.Log("la valvula está  " + activado);
	}

}

[PunRPC]
    void RPC_encenderValvula(bool activadoRPC)
    {
        
        activado = activadoRPC;
        Debug.Log("Mi valvula está... " + activadoRPC);
    }
}