using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PonerMapa : MonoBehaviour
{
	public GameObject mapa;
	public GameObject yoBoton;
	public Button boton1;
	public Button boton2;
    public Button boton3;
    public GameObject canvas;
	public GameObject imgWire;
	public GameObject fondo;
    public GameObject SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
           // mapa.SetActive(false);
            boton1.gameObject.SetActive(false);
            boton2.gameObject.SetActive(false);
            boton3.gameObject.SetActive(false);
            canvas.SetActive(false);
            
           

        }
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            yoBoton.SetActive(false);
            imgWire.SetActive(false);
            fondo.SetActive(false);
            mapa.SetActive(true);
            boton1.gameObject.SetActive(true);
            boton2.gameObject.SetActive(true);
            boton3.gameObject.SetActive(true);
            canvas.SetActive(true);
            SpawnPoint.SetActive(true);
        }

    }


    public void mostrarMapa(){
    	//mapa.SetActive(true);
    	yoBoton.SetActive(false);
    	boton1.gameObject.SetActive(true);
        boton2.gameObject.SetActive(true);
        boton3.gameObject.SetActive(true);
        canvas.SetActive(true);
        imgWire.SetActive(false);
        fondo.SetActive(false);
        
    }


    // Update is called once per frame
   /* void Update()
    {
        
    }*/
}
