using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PuertasUbicadas : MonoBehaviour
{
    /* Este script se va a utilizar para crear un array de puertas
     * con un estado isSeleceted que puede ser true o false
     * y un botón asignado a casa una*/
    public bool IsSelected { get; set; }
    public Button botonAsignado;
    public bool IsFound;
}
