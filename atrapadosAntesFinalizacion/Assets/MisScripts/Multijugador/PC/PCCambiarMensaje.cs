using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCCambiarMensaje : MonoBehaviour
{
    public Text mensajeEspacio;
    void Start()
    {
       mensajeEspacio.text = IniciarBoton.mensaje;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
