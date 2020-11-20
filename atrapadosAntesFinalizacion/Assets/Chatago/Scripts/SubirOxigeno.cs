using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubirOxigeno : MonoBehaviour
{
  [SerializeField]
 private int vida; 
 public bool enLaZona;

 //public GameObject zona;
 
    // Start is called before the first frame update
    void Start()
    {
        vida = 80;
        enLaZona = false;
        
    }

    // Update is called once per frame
    void Update()
    {
    	//cambiarVida();
       }


    void OnTriggerEnter(Collider sitio){
if (sitio.gameObject.tag == "zona"){
	enLaZona = true;
    	InvokeRepeating("subir", 0.01f, 0.3f);
    	CancelInvoke("bajar");
	//Debug.Log("teta");
    }
    }

    void OnTriggerExit(Collider sitio)
    {
        if (sitio.gameObject.tag == "zona"){
        	InvokeRepeating("bajar", 0.01f, 2.0f);
        	CancelInvoke("subir");
        	enLaZona = false;
        	//Debug.Log("tres tetas");
        }
    }

    void cambiarVida(){
    	if (enLaZona == true){
    		InvokeRepeating("subir", 0.01f, 2.0f);
    	}
    	else if (enLaZona == false){
    		InvokeRepeating("bajar", 0.01f, 1.0f);
    	}
    }

    void subir(){
    	if (vida>1 &&vida<100){
    	vida++;
    }
    }


    void bajar(){
    	if (vida>=0 && vida<101){
    	vida--;
    }
    	
    }
}
