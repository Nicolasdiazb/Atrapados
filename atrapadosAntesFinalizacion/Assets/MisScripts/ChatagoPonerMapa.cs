using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChatagoPonerMapa : MonoBehaviour
{
	public GameObject mapa;
	public GameObject yoBoton;
	public GameObject boton1;
	public GameObject boton2;
	public GameObject boton3;
	public GameObject canvas;
	public GameObject imgWire;
	public GameObject fondo;
    // Start is called before the first frame update
    void Start()
    {
        mapa.SetActive(false);
        boton1.SetActive(false);
        boton2.SetActive(false);
        boton3.SetActive(false);
        canvas.SetActive(false);

       
         
    }


   public void mostrarMapa(){
    	mapa.SetActive(true);
    	yoBoton.SetActive(false);
    	boton1.SetActive(true);
        boton2.SetActive(true);
        boton3.SetActive(true);
        canvas.SetActive(true);
        imgWire.SetActive(false);
        fondo.SetActive(false);
        }


    // Update is called once per frame
   /* void Update()
    {
        
    }*/
}
