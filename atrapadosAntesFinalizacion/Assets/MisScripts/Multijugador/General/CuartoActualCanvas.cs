using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuartoActualCanvas : MonoBehaviour
{
    /* Está dentro del objeto CuartoActualCanvas
     * Se encarga de activar o desactivar al 
     * objeto CuartoActualCanvas. 
     */

    private CanvasCuarto _canvasCuarto;

    public void InicializarPrimero(CanvasCuarto doscanvas)
    {
        _canvasCuarto = doscanvas;
    }
    //Mostrar canvas
    public void Mostrar()
    {
        gameObject.SetActive(true);
    }
    //Esconder canvas
    private void Esconder()
    {
        gameObject.SetActive(false);
    }
    // IR AL SCRIPT DesplazamientoPantallas.cs
}
