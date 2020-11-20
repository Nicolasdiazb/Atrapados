using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RotarMapa : MonoBehaviour
{
    public static RotarMapa RM;
    private Touch toque;
    //Área en específico. 
    //private Vector2 posicionToque;

    private Quaternion rotacionY;
    private GameObject repJugadorAR;
    private float velocidadRotacion = 0.1f;
    private GameObject playerAvatar;
    private PhotonView PVR;
    public Quaternion rot;
   

    // Start is called before the first frame update

    void Start()
    {
        // playerAvatar = GameObject.FindWithTag("playeravatar");
        repJugadorAR = GameObject.FindWithTag("jugadorVR");
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            toque = Input.GetTouch(0);
            //Si toqué y me moví
            if (toque.phase == TouchPhase.Moved)
            {
                rotacionY = Quaternion.Euler(0f, -toque.deltaPosition.x * velocidadRotacion, 0f);
                transform.rotation = rotacionY * transform.rotation;
                //  playerAvatar.GetComponent<MoverJugadores>().enabled = false;
                /*if(PVR.IsMine)
                {
                    PVR.RPC("RPC_EnviarRotacion", RpcTarget.All, gameObject.GetPhotonView().ViewID);
                }*/
            }
        }
        else
        {
            // playerAvatar.GetComponent<MoverJugadores>().enabled = true;
        }
    }

    /*[PunRPC]
    void RPC_EnviarRotacion(int rotacion)
    {
        rot = PhotonView.Find(rotacion).transform.rotation;
        repJugadorAR.GetComponent<MoverRep>().rotarJ(rotacion);
    }*/
}
