using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Seleccionar : MonoBehaviour
{
    // Variable privada que se puede modificar desde el inspector
    [SerializeField]
    // Arreglo de puertas con el script PuertasUbicadas
     public PuertasUbicadas[] puertasUbicadas;
    [SerializeField]
    // Arreglo de ductos con el script DuctosUbicacion
    private DuctosUbicacion[] ductosUbicados;
    [SerializeField]
    private Camera camaraAR;
    //x y y 
    private Vector2 toquePosicion = default;

    bool yaEntre = false;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Si la pantalla fue tocada
        if (Input.touchCount > 0)
        {
            //Usar cero para tomar el primer toque en pantalla
            Touch toque = Input.GetTouch(0);
            //Almacenar posición del toque
            toquePosicion = toque.position; 
            //Fase de inicio (explicar fase)
            if(toque.phase == TouchPhase.Began)
            {
                Ray ray = camaraAR.ScreenPointToRay(toque.position);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    //Intentar encontrar el script
                    PuertasUbicadas puertasUbicadas = hit.transform.GetComponent<PuertasUbicadas>();
                    DuctosUbicacion ductosUbicados = hit.transform.GetComponent<DuctosUbicacion>();
                    if (puertasUbicadas != null)
                    {
                        empezarBotonPuerta(puertasUbicadas);
                    }
                    else if(ductosUbicados != null)
                    {
                        empezarBotonDucto(ductosUbicados);
                    }

                }
            }

        }
    }

    void empezarBotonPuerta(PuertasUbicadas seleccionado)
    {
        
        foreach(PuertasUbicadas a in puertasUbicadas)
        {
            Animator animadorPuerta = a.GetComponent<Animator>();
            MeshRenderer aja = a.GetComponent<MeshRenderer>();
            Button q = a.GetComponent<PuertasUbicadas>().botonAsignado;
            if (seleccionado == a)
            {
                if (yaEntre == false)
                {
                    q.gameObject.SetActive(true);
                    yaEntre = true;

                }
                else
                {
                    q.gameObject.SetActive(false);
                    yaEntre = false;
                }

                a.IsSelected = true;
            }
            else
            {
                
                a.IsSelected = false;
            }
    
        }
    }


    void empezarBotonDucto(DuctosUbicacion seleccionado)
    {

        foreach (DuctosUbicacion a in ductosUbicados)
        {
            Animator animadorPuerta = a.GetComponent<Animator>();
            MeshRenderer aja = a.GetComponent<MeshRenderer>();
            Button q = a.GetComponent<DuctosUbicacion>().botonAsignado;
            if (seleccionado == a)
            {
                if (yaEntre == false)
                {
                    q.gameObject.SetActive(true);
                    yaEntre = true;
                }
                else
                {
                    q.gameObject.SetActive(false);
                    yaEntre = false;
                }

                a.IsSelected = true;
            }
            else
            {
                a.IsSelected = false;
            }


        }
    }

}
