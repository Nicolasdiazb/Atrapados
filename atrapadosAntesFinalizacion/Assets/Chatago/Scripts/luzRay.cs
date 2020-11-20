using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class luzRay : MonoBehaviour
{

	public bool hayLuz = false;
	public GameObject yo;
	public Material on;
	public Material off;
	private PhotonView PhotonV;
	private Collider coll;
	public Camera camaraPC;
    // Start is called before the first frame update
    void Start()
    {
        PhotonV = GetComponent<PhotonView>();
         coll = GetComponent<Collider>();
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
                Debug.Log("estoy tocando mi boton");
                activacion();
            }
        
    }
    }

    void activacion(){

        if (hayLuz == true)
        {
            hayLuz = false;
            Debug.Log("Hay luz");
        }
        else if (hayLuz == false)
        {
            hayLuz = true;
            Debug.Log("No hay luz");
        }

PhotonV.RPC("RPC_enviarValorLuz", RpcTarget.Others, hayLuz);
        
        if(hayLuz==true){
yo.GetComponent<Renderer>().material = on;
        } else if(hayLuz ==false){
yo.GetComponent<Renderer>().material = off;
        }
    }
[PunRPC]
    void RPC_enviarValorLuz(bool valorLuz)
    {
        Debug.Log("Valor luz");
        hayLuz = valorLuz;
        Debug.Log("Luz Rpc " + valorLuz);
    }
}
