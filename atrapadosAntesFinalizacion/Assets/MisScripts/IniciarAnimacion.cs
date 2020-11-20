using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class IniciarAnimacion : MonoBehaviour
{
    GameObject ductos;
    GameObject puerta;
    Animator animadorDucto;
    Animator animadorPuerta;

    bool yaEntre = false;
    // Start is called before the first frame update
    void Start()
    {
        //Busca a los objetos según su nombre. 
        ductos = GameObject.Find("Ducto1");
        puerta = GameObject.Find("Puerta1");
        //Obtiene su animator
        animadorDucto = ductos.GetComponent<Animator>();
        animadorPuerta = puerta.GetComponent<Animator>();

        ///asignarValor();

    }

    // Update is called once per frame
    void Update()
    {
        //Si se hace click o si se toca la pantalla
        if (Input.GetMouseButtonDown(0)) {
            //Guardar en un rayo que convierta ese toque en la pantalla en rayo
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Guarda información sobre el rayo
            RaycastHit hit;
            //¿Colisionó con algo?
            if (Physics.Raycast(ray, out hit)){
                //¿Con qué colisionó?
                if (hit.transform.name == "Ducto1") {
                    if (yaEntre == false)
                    {
                        animadorDucto.SetBool("estaAbierta", true);
                        animadorDucto.SetBool("estaCerrada", false);
                        yaEntre = true;

                    }
                    else {
                        animadorDucto.SetBool("estaAbierta", false);
                        animadorDucto.SetBool("estaCerrada", true);
                        yaEntre = false;
                    }

                }

                if (hit.transform.name == "Puerta1")
                {
                    if (yaEntre == false)
                    {
                        animadorPuerta.SetBool("puertaAbierta", true);
                        animadorPuerta.SetBool("puertaCerrada", false);
                        yaEntre = true;
                        Debug.Log("aaa2");

                    }
                    else
                    {
                        animadorPuerta.SetBool("puertaAbierta", false);
                        animadorPuerta.SetBool("puertaCerrada", true);
                        yaEntre = false;
                    }
               
                }
            }
        }
    }


}
