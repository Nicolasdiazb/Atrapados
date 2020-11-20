using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiltrarElementos : MonoBehaviour
{
    // Se crea un arreglo para almacenar todas las puertas
    [SerializeField]
    private PuertasUbicadas[] puertasUbicadas;
    GameObject[] puerta;
    GameObject[] ducto;
    // Botones de filtro
    public Button filtrarP;
    public Button filtrarD;
    // Variable para detectar si le di click 
    bool colorInicial = true;
    bool colorInicial2 = true;
    public Color32 colorNaranja= new Color32(255, 178, 83,1);
    public Color32 colorMorado = new Color32(126, 74, 207,1);
    public Color colorOriginal = new Color32(20, 255, 246,1);
    
    // Imagen para cambiar en el botón
    public Sprite imageOnP;
    public Sprite imageOffP;
    public Sprite imageOnD;
    public Sprite imageOffD;

    void Start()
    {
        // Se mete a todos los objetos con tag "puerta" y "ductos" en el arreglo 
        puerta = GameObject.FindGameObjectsWithTag("puerta");
        ducto = GameObject.FindGameObjectsWithTag("ducto");

    }

    //Función que se dispara cuando hay click en el botóm 
    public void cambiarColorPuerta()
     {
             //Si colorInicial es verdadero entonces....
             if (colorInicial)
             {
                 //Se va a recorrer todo el arreglo de las puerta y se va a cambiar el color a verde. 
                 for (int i = 0; i < puerta.Length; i++)
                 {
                     //TO-DO: METER ÍCONO
                     puerta[i].GetComponent<Renderer>().material.color = colorMorado;
                    puerta[i].GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
               // puerta[i].GetComponent<Renderer>().material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                puerta[i].GetComponent<Renderer>().material.SetColor("_EmissionColor",colorMorado);
                puerta[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                colorInicial = false;
                 }
             //Cambiar la imagen 
             filtrarP.GetComponent<Image>().sprite = imageOnP;


         }
             //Si colorInicial es falso entonces....
             else
             {
                 //Se va a recorrer todo el arreglo de las puerta y se va deja en color original. 
                 for (int i = 0; i < puerta.Length; i++)
                 {
                     puerta[i].GetComponent<Renderer>().material.color = colorOriginal;
                     puerta[i].GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
                //puerta[i].GetComponent<Renderer>().material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                puerta[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", colorOriginal);
                puerta[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                colorInicial = true;

                    }
             //Estado Original
             filtrarP.GetComponent<Image>().sprite = imageOffP;
             //puertaB.gameObject.SetActive(false);
         }
     }
     public void cambiarColorDucto()
     {
         //Si colorInicial es verdadero entonces....
             if (colorInicial2)
             {
                 //Se va a recorrer todo el arreglo de las puerta y se va a cambiar el color a verde. 
                 for (int i = 0; i < ducto.Length; i++)
                 {
                 //TO-DO: METER ÍCONO
                     ducto[i].GetComponent<Renderer>().material.color = colorNaranja;
                     ducto[i].GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
                     //ducto[i].GetComponent<Renderer>().material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                    ducto[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", colorNaranja);
                    ducto[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                colorInicial2 = false;

                 }
             filtrarD.GetComponent<Image>().sprite = imageOnD;
           //  ductoB.gameObject.SetActive(true);
         }
             //Si colorInicial es falso entonces....
             else
             {
                 //Se va a recorrer todo el arreglo de las puerta y se va deja en color original. 
                 for (int i = 0; i < ducto.Length; i++)
                 {
                    ducto[i].GetComponent<Renderer>().material.color = colorOriginal;
                    ducto[i].GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
                ducto[i].GetComponent<Renderer>().material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
                ducto[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", colorOriginal);
                ducto[i].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                colorInicial2 = true;

                 }
             filtrarD.GetComponent<Image>().sprite = imageOffD;
            // ductoB.gameObject.SetActive(false);
         }
     }
}
