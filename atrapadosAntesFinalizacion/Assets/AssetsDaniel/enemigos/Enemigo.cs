using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    NavMeshAgent agente;
    private GameObject miJugadorVR;
    public GameObject miOrdenInicialADondeIR;
    private float distanciaAlJugador;
    //Representación del enemigo en el mapa de AR
    public GameObject representacionEnemigo;
   

    void Start()
    {
        agente = this.GetComponent<NavMeshAgent>();
        miJugadorVR = GameObject.Find("XR Rig");

        

    }

    void Perseguir(Vector3 aQuien)
    {
      
        agente.SetDestination(aQuien);
    }



    void Update()
    {
        //Debug.DrawRay(transform.position, Vector3.forward, Color.green);
        distanciaAlJugador = Vector3.Distance(miJugadorVR.transform.position, transform.position);
        //Debug.Log(distanciaAlJugador);

        if (distanciaAlJugador > 10.0f) {

            Perseguir(miOrdenInicialADondeIR.transform.position);
        }
        else
        {

            Perseguir(miJugadorVR.transform.position);
        } 

        //posicion a mapear, inicioGrande, finalGrande, inicioPequeño, finalPequeño, limite
        float posicionZ = mapearPosicion(transform.localPosition.z, -65.2f, 71.9f, -8.52f, 9.46f, 9.46f);
        float posicionX = mapearPosicion(transform.localPosition.x, -28.61f, 24.2f, -2.7f, 4.28f, 4.28f);
        representacionEnemigo.GetComponent<MoverRep>().moverMapeo(posicionX, posicionZ);

    }

    //Métodos para el mapeo
    //posicion a mapear, inicioGrande, finalGrande, inicioPequeño, finalPequeño, limite
    public float mapearPosicion(float n, float start1, float stop1, float start2, float stop2, float limites)
    {
        float valorNuevo = (n - start1) / (stop1 - start1) * (stop2 - start2) + start2;
        if (valorNuevo != limites)
        {
            return valorNuevo;
        }
        if (start2 < stop2)
        {
            return Constrain(valorNuevo, start2, stop2);
        }
        else
        {
            return Constrain(valorNuevo, stop2, start2);
        }
    }

    public float Constrain(float n, float low, float high)
    {

        return Mathf.Max(Mathf.Min(n, high), low);
    }

}
