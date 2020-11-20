using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejoCamara : MonoBehaviour
{
     //Para agregar una nueva camara, simplemente hay que ponerla en el inspector como hija de "CameraController" y en la posicion de mas abajo.

    //Arreglo para poner la cantidad de camaras y pantallas deseadas.
    
    Transform[] cameras;
    int camaraSeleccionada = -1;
    private static int NumPantalla = 0;
    private static bool seHaSeleccionadoCamara;

    void Start()
    {
        //El tamano del arreglo es la cantidad de hijos de "CameraController"
        cameras = new Transform[transform.childCount];
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i] = transform.GetChild(i).GetComponent<Transform>();
        }
    }

    void Update()
    {
        //Debug.Log("se ha seleccionado una camara: " + seHaSeleccionadoCamara);
        //Debug.Log(camaraSeleccionada);
        if(seHaSeleccionadoCamara)
        {
            for (int i = 0; i < cameras.Length; i++)
            {
                if (i == NumPantalla - 1)
                {
                    camaraSeleccionada = i;
                    break;
                }
            }

            if (Input.GetKey(KeyCode.A))
            {
                cameras[camaraSeleccionada].Rotate(Vector3.down * Time.deltaTime * 30);
            }
            if (Input.GetKey(KeyCode.D))
            {
                cameras[camaraSeleccionada].Rotate(Vector3.up * Time.deltaTime * 30);
            }
        }
        else
        {
            camaraSeleccionada = -1;
        }
    }

    public void CancelarManejos()
    {
        seHaSeleccionadoCamara = false;
    }

    public void ManejarCamaras(int numPantalla)
    {
        NumPantalla = numPantalla;
        seHaSeleccionadoCamara = true;
        Debug.Log("Se ha tocado la pantalla " + numPantalla);
    }
}
