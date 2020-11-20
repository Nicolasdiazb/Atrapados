using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCuarto : MonoBehaviour
{   /*Primer Script a revisar. Está dentro del objeto OverlayCanvas
    * el cual almacena el canvas de creación de cuartos y 
    * selección de jugador. 
    */

    //Guarda los canvas creados. 
    [SerializeField]
    private CrearUnirseCanvas _crearUniverseCanvas; //Canvas para crear o unirse a un cuarto. 

    [SerializeField]
    private CuartoActualCanvas _cuartoActualCanvas; //Canvas selección personaje

    //Singletons para poder acceder a variables o métodos
    public CrearUnirseCanvas CrearUnirseCanvas { get { return _crearUniverseCanvas;  } }

    public CuartoActualCanvas CuartoActualCanvas { get { return _cuartoActualCanvas; } }

    //Los canvas creados necesitan "saber de la existencia" del padre


    private void Awake()
    {
        InicializarPrimero();
    }

    //
    private void InicializarPrimero()
    {
        //Las clases se retornan a sí mismas 
        CuartoActualCanvas.InicializarPrimero(this);
        CrearUnirseCanvas.InicializarPrimero(this);
    }
    // IR AL SCRIPT CrearUnirseCanvas.cs
}
