using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAR : MonoBehaviour
{
    
    //Boton de filtrar puertas
    public GameObject filtrarPuerta;
    //puerta titilate
    public GameObject puerta;
    public GameObject puertaWire;
    //boton puerta 
    public GameObject botonPuerta;
    //Botón girar y acercar
    public GameObject girarAcercar;
    //Enemigos
    public GameObject[] enemigos;
    //Jugaodr
    public GameObject jugador;
    //boton hablar
    public GameObject botonHablar;

    //Audios
    public AudioSource audioPuertas;
    public AudioSource audioConsejo;
    public AudioSource audioMovimiento;
    public AudioSource audioAcercarAlejar;
    public AudioSource audioHablar;
    public AudioSource audioFinal;

    public Color colorOriginal = new Color32(126, 74, 207, 1);
    public Color colorTitilante = new Color32(126, 74, 207, 1);
    private int contador = 0;

    public bool mover = false;
    public bool color = false;
    public bool final;

    void Start()
    {
        //filtrarPuerta = GameObject.Find("FiltrarPuertas");
        
        botonPuerta = GameObject.Find("BotonPuerta3");
       // girarAcercar = GameObject.Find("GirarAgrandar");
        //enemigos[0] = GameObject.Find("enemigo0");
        
       
        StartCoroutine(ComenzarAudio());
        
    }

    
    IEnumerator ComenzarAudio()
    {
        yield return new WaitForSeconds(2);
        filtrarPuerta.SetActive(true);
        audioPuertas.Play();
        StartCoroutine(PausaPuerta());
    }

    IEnumerator PausaPuerta()
    {
        yield return new WaitForSeconds(2.8f);
        audioPuertas.Pause();
        StartCoroutine(InteraccionPuerta());
        final = true;
    }

    IEnumerator InteraccionPuerta()
    {
        yield return new WaitForSeconds(1);
        audioPuertas.Play();
        StartCoroutine(InteraccionPuerta2());
        
    }

    IEnumerator InteraccionPuerta2()
    {
        yield return new WaitForSeconds(4);
        color = true;
        CambiarColor();
        StartCoroutine(Consejo());
    }

     IEnumerator Consejo()
    {
      yield return new WaitForSeconds(2);
        audioConsejo.Play();
        StartCoroutine(GirarAcercar());

    }

     IEnumerator GirarAcercar()
    {
        yield return new WaitForSeconds(5);
        color = false;
        girarAcercar.SetActive(true);
        audioAcercarAlejar.Play();
        StartCoroutine(MoverPersonajes());

    }
    IEnumerator MoverPersonajes()
    {
        yield return new WaitForSeconds(8);
        audioMovimiento.Play();
        mover = true;
        StartCoroutine(Hablar());
    }

    IEnumerator Hablar()
    {
        yield return new WaitForSeconds(10);
         mover = false;
        botonHablar.SetActive(true);
        audioHablar.Play();
        
    }


    private void Update()
    {
        if (mover)
        {
            jugador.transform.Translate(Vector3.forward * 0.1f * Time.deltaTime);
            enemigos[0].transform.Translate((Vector3.forward * -1) * 0.2f * Time.deltaTime);
            enemigos[3].transform.Translate((Vector3.forward * -1) * 0.2f * Time.deltaTime);
            enemigos[1].transform.Translate((Vector3.right * -1)* 0.2f * Time.deltaTime);
            enemigos[2].transform.Translate(Vector3.right * 0.2f * Time.deltaTime);
        }
    
        
    }

  
    public void CambiarColor()
    {
        colorTitilante = new Color32(126, 74, 207, 1);

        if (color)
        {
            puerta.GetComponent<Renderer>().material.SetColor("_Color", colorTitilante);
            puerta.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            puerta.GetComponent<Renderer>().material.SetColor("_EmissionColor", colorTitilante);
            puerta.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");

            puertaWire.GetComponent<Renderer>().material.SetColor("_Color", colorTitilante);
            puertaWire.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            puertaWire.GetComponent<Renderer>().material.SetColor("_EmissionColor", colorTitilante);
            puertaWire.GetComponent<Renderer>().material.EnableKeyword("_EMISSION"); 
        }

    }

}
