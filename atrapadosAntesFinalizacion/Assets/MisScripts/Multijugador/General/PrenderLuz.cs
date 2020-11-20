using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PrenderLuz : MonoBehaviour
{
    /* Este script se encarga de cambiar el valor 
     * de una variable booleana para que ésta actúe
     * como un interruptor en el canvas de BotonesPC.
     */

    //Variable de interruptor
    public bool hayLuz = false;
public Sprite off;
    public Sprite on;
    public Button yo;
    //PhotonView de cada uno de los botones. PhotonView sirve para poder enviar datos a través de la red. 
    private PhotonView PhotonV;

    void Start()
    {
        PhotonV = GetComponent<PhotonView>();
    }

    //Este es el método que tiene que estar en el onClick de cada botón.. 
    public void encenderLuz()
    {
        Debug.Log("Intento encender luz");
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
       
        
            Debug.Log("Quiero enviar un RPC");
            PhotonV.RPC("RPC_enviarValorLuz", RpcTarget.Others, hayLuz);
        
        if(hayLuz == true && yo.image.sprite == off)
     {
        yo.image.sprite = on;
     }
        else if(hayLuz == false && yo.image.sprite == on)
        {
            yo.image.sprite = off;
        }

    }

    //RPC para pasar el valor de hayLuz a todos los jugadores 

    [PunRPC]
    void RPC_enviarValorLuz(bool valorLuz)
    {
        Debug.Log("Valor luz");
        hayLuz = valorLuz;
        Debug.Log("Luz Rpc " + valorLuz);
    }
}
//IR AL SCRIPT IniciarBoton.cs
