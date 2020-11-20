using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialChatago : MonoBehaviour
{

	public GameObject botonDuctoF;
    public GameObject botonPuertaF;
    public GameObject botonZoomRotar;
    public GameObject hudOxigeno;
    public AudioSource audioTutorialOxigeno;
    public AudioSource audioTutorialDuctos;
    public AudioSource audioTutorialPuertas;
    public AudioSource audioTutorialTocar;
    public AudioSource audioTutorialRotarAcercar;
    public GameObject mapa;
    public Text instrucciones;
    public Text continuar;
    public GameObject botonSiguienteEscena;
   //public GameObject  mano;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Puertas());
        mapa = GameObject.FindWithTag("mapa");
       
        BotonesPuertaUbicados puertasUbicadas = gameObject.GetComponent<BotonesPuertaUbicados>();
    }

    // Update is called once per frame
 
    IEnumerator Ductos()
    {
        yield return new WaitForSeconds(5);
        //Bienvenido Julian tu principal objetivo
        audioTutorialPuertas.Stop();
        audioTutorialDuctos.Play();
        botonDuctoF.SetActive(true);
        instrucciones.text = "Toca los botones para filtrar";
        //mano.transform.position = new Vector2(0, 5);
        StartCoroutine(TocarMapa());


    }
    IEnumerator Puertas()
    {
        yield return new WaitForSeconds(2);
        //Bienvenido Julian tu principal objetivo
        mapa.GetComponent<RotarMapa>().enabled = false;
        audioTutorialPuertas.Play();
        botonPuertaF.SetActive(true);
        StartCoroutine(Ductos());

    }
    IEnumerator TocarMapa()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Estoy tocar");
        //Bienvenido Julian tu principal objetivo
        audioTutorialDuctos.Stop();
        audioTutorialTocar.Play();
        instrucciones.text = "Toca una puerta o un filtro";
        StartCoroutine(RotarMapa());
        
    }
    IEnumerator RotarMapa()
    {
        yield return new WaitForSeconds(6);
        Debug.Log("Estoy rotar");
        //Bienvenido Julian tu principal objetivo
        botonZoomRotar.SetActive(true);
        audioTutorialTocar.Stop();
        audioTutorialRotarAcercar.Play();
        mapa.GetComponent<RotarMapa>().enabled = true;
        instrucciones.text = "Toca una puerta o un filtro";
        StartCoroutine(Oxigeno());
    }
  IEnumerator Oxigeno()
    {
        yield return new WaitForSeconds(6);
        //Bienvenido Julian tu principal objetivo
        hudOxigeno.SetActive(true);
        audioTutorialRotarAcercar.Stop();
        audioTutorialOxigeno.Play();
        StartCoroutine(Continuar());
    }

    IEnumerator Continuar(){
    	yield return new WaitForSeconds(6);

    	continuar.text = "CONTINUAR";
    }

   
}
