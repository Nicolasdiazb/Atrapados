using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotarAcercar : MonoBehaviour
{
    // Imagen para cambiar en el botón
    public Sprite imageRotar;
    public Sprite imageAcercar;
    private bool estoyRotando = true;
    public Button botonRA;
    public GameObject mapa;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void evaluarBoton()
    {
        if (estoyRotando)
        {
            botonRA.GetComponent<Image>().sprite = imageRotar;
            mapa.GetComponent<NuevoZoomSize>().enabled = false;
            mapa.GetComponent<RotarMapa>().enabled = true;
            estoyRotando = false;
        }
        else
        {
            botonRA.GetComponent<Image>().sprite = imageAcercar;
            mapa.GetComponent<RotarMapa>().enabled = false;
            mapa.GetComponent<NuevoZoomSize>().enabled = true;
            estoyRotando = true;
        }
    }
}
