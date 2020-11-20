using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearUnirseCanvas : MonoBehaviour
{
    //Almacena e inicializa los Scripts para crear y unirse a un cuarto
    [SerializeField]
    private CrearCuarto _crearCuarto;
    [SerializeField]
    private UnirCuarto _unirCuarto;
    private CanvasCuarto _canvasCuarto;

    public void InicializarPrimero(CanvasCuarto doscanvas)
    {
        _canvasCuarto = doscanvas;
        _crearCuarto.InicializarPrimero(doscanvas);
        _unirCuarto.InicializarPrimero(doscanvas);
    }
    //IR AL SCRIPT CrearCuarto.cs
}