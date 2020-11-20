using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARMic : MonoBehaviour
{
    public int contadorMic;
    public Text numero;
    public Text mensaje;
    public Text boton;
    public bool hablando = false;
    public GameObject pantallaPerder;
    public Sprite imageOn;
    public Sprite imageOff;
    public GameObject sonidoRep;
    public Sprite est1;
    public Sprite est2;
    public Sprite est3;
    public Sprite est4;
    void Start()
    {
        sonidoRep = GameObject.FindGameObjectWithTag("sonido");
        numero.text = contadorMic.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void Hablar()
    {
        if(hablando == false)
        {
            hablando = true;
            gameObject.GetComponent<Image>().sprite = imageOn;
            sonidoRep.GetComponent<Image>().enabled = true;
             InvokeRepeating("CambiarAnimacion", 1.0f, 3.0f);
        }
        else if(hablando == true)
        {
           // sonidoRep.SetActive(false);
            gameObject.GetComponent<Image>().sprite = imageOff;
            sonidoRep.GetComponent<Image>().enabled = false;
            if (contadorMic < 5)
            {
                contadorMic++;
                numero.text = contadorMic.ToString();
                evaluarMensaje();
            }
            else
            {
                numero.text = contadorMic.ToString();
                pantallaPerder.SetActive(true);
                
            }
            hablando = false;
        }
       

    }

    public void evaluarMensaje()
    {

        if(contadorMic == 3)
        {
            mensaje.text = "Ten cuidado. Si sigues hablando te encontrarán.";
        }
        else if(contadorMic == 5)
        {
           
        }
        else
        {
            mensaje.text = "";
        }
        
        
    }

    
    public void CambiarAnimacion()
    {
        sonidoRep.GetComponent<Image>().sprite = est1;
        InvokeRepeating("CambiarAnimacion2", 1.0f, 3.0f);
    }
    public void CambiarAnimacion2()
    {
        sonidoRep.GetComponent<Image>().sprite = est2;
        InvokeRepeating("CambiarAnimacion3", 1.0f, 3.0f);
    }
    public void CambiarAnimacion3()
    {
        sonidoRep.GetComponent<Image>().sprite = est3;
        InvokeRepeating("CambiarAnimacion3", 1.0f, 3.0f);
    }
    public void CambiarAnimacion4()
    {
        sonidoRep.GetComponent<Image>().sprite = est4;
        InvokeRepeating("CambiarAnimacion", 1.0f, 3.0f);
    }



}
