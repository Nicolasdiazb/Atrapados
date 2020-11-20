using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MoverJugadores : MonoBehaviour
{
    public static MoverJugadores MJ;
    private float velocidadMovimiento;
    private GameObject repJugadorAR;
    public Vector3 pos;
    public Vector3 pos2;
    private GameObject mapaAR;
    private PhotonView PV;
    private PhotonView PVR;
    public Vector3 posicionCubo;
    public MoverRep rep;
    public Transform transformCubo;
    public GameObject mapaVR;
    float vY;
    float vX;

    float vY2;
    float vX2;

    float movY;

    void Start()
    {
        velocidadMovimiento = 1;
        //Represaentación de VR en AR
        repJugadorAR = GameObject.FindWithTag("jugadorVR");
        mapaAR = GameObject.FindWithTag("mapa");
        mapaVR = GameObject.FindWithTag("mapaVR");
        //la variable pos define el movimiento de repJugadorAR, el cual depende el 
        //movimiento del jugador VR
        Debug.Log("Estoy en mover");
        PV = GetComponent<PhotonView>();
        PVR = repJugadorAR.GetComponent<PhotonView>();
        repJugadorAR.transform.SetParent(mapaAR.transform);
        posicionCubo = transform.position;
        transformCubo = transform;
        vY = mapaVR.GetComponent<Collider>().bounds.size.z;
        vX = mapaVR.GetComponent<Collider>().bounds.size.x;
        vY2 = mapaAR.GetComponent<Collider>().bounds.size.z;
        vX2 = mapaAR.GetComponent<Collider>().bounds.size.x;
       
}

    void Update()
    {
        posicionCubo = transform.position;
        transform.Translate(velocidadMovimiento * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, velocidadMovimiento * Input.GetAxis("Vertical") * Time.deltaTime);
        movY = Remap(repJugadorAR.transform.position.z, -6.15615f, -6.15615f, vY2, vY);
       // Debug.Log(movY);
        //repJugadorAR.GetComponent<MoverRep>().moverJ(posicionCubo,  gameObject.GetPhotonView().ViewID, movY);
    }


    public float Remap(float from, float fromMin, float fromMax, float toMin, float toMax)
    {
        var result = Mathf.Lerp(fromMax, toMax, Mathf.InverseLerp(from, fromMin, toMin));

        return result;

    }


    

}