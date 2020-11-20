using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MoverRep : MonoBehaviour
{
    public static MoverRep MR;
    private PhotonView PVR;
    private Transform cuboVR;
    private Quaternion rotacion;
    public GameObject mapaAR;
    public GameObject mapaVR;
    float vY;
    float vX;

    float vY2;
    float vX2;

    float movY;

    void Start()
    {
        PVR = GetComponent < PhotonView>();
        vY = mapaVR.GetComponent<Collider>().bounds.size.z;
        vX = mapaVR.GetComponent<Collider>().bounds.size.x;
        vY2 = mapaAR.GetComponent<Collider>().bounds.size.z;
        vX2 = mapaAR.GetComponent<Collider>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public void moverMapeo(float posX, float posZ)
    {
        PVR.RPC("RPC_EnviarDir", RpcTarget.All, posX, posZ);

    }

    [PunRPC]
    void RPC_EnviarDir(float posX, float posZ)
    {
        transform.localPosition = new Vector3(posX, 3.4f, posZ);

    }



}
