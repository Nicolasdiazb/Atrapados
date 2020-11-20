using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgresoTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject botonDuctoF;
    public GameObject botonPuertaF;
    public AudioSource audioTutorial1;
    public AudioSource audioTutorialDuctos;
    public AudioSource audioTutorialPuertas;
    public AudioSource audioTutorialTocar;
    public AudioSource audioTutorialRotar;
    public GameObject mapa;
    public Text instrucciones;
    
   /* public PuertasUbicadas[] puertasUbicadas;
    public DuctosUbicacion[] ductosUbicacion;*/
    public GameObject botonSiguienteEscena;
    void Start()
    {
        StartCoroutine(ComenzarAudio());
        mapa = GameObject.FindWithTag("mapa");
       
        BotonesPuertaUbicados puertasUbicadas = gameObject.GetComponent<BotonesPuertaUbicados>();
    }

 
    IEnumerator ComenzarAudio()
    {
        yield return new WaitForSeconds(2);
        //Bienvenido Julian tu principal objetivo
        mapa.GetComponent<RotarMapa>().enabled = false;
        audioTutorial1.Play();
       /* for(int  i = 0; i < puertasUbicadas.Length; i++)
        {
            puertasUbicadas[i].GetComponent<PuertasUbicadas>().enabled = false;
        }
        for (int i = 0; i < ductosUbicacion.Length; i++)
        {
            ductosUbicacion[i].GetComponent<DuctosUbicacion>().enabled = false;
        }*/
        StartCoroutine(Puertas());
    }

    IEnumerator Ductos()
    {
        yield return new WaitForSeconds(5);
        //Bienvenido Julian tu principal objetivo
        audioTutorialPuertas.Stop();
        audioTutorialDuctos.Play();
        botonDuctoF.SetActive(true);
        instrucciones.text = "Toca los botones para filtrar";
        StartCoroutine(TocarMapa());


    }
    IEnumerator Puertas()
    {
        yield return new WaitForSeconds(9);
        //Bienvenido Julian tu principal objetivo
        audioTutorial1.Stop();
        audioTutorialPuertas.Play();
        botonPuertaF.SetActive(true);
        StartCoroutine(Ductos());

    }
    IEnumerator TocarMapa()
    {
        yield return new WaitForSeconds(6);
        Debug.Log("Estoy tocar");
        //Bienvenido Julian tu principal objetivo
        audioTutorialDuctos.Stop();
        audioTutorialTocar.Play();
       /* for (int i = 0; i < puertasUbicadas.Length; i++)
        {
            puertasUbicadas[i].GetComponent<PuertasUbicadas>().enabled = true;
        }
        for (int i = 0; i < ductosUbicacion.Length; i++)
        {
            ductosUbicacion[i].GetComponent<DuctosUbicacion>().enabled = true;
        }*/
        instrucciones.text = "Toca una puerta o un filtro";
        StartCoroutine(RotarMapa());
        
    }
    IEnumerator RotarMapa()
    {
        yield return new WaitForSeconds(8);
        Debug.Log("Estoy rotar");
        //Bienvenido Julian tu principal objetivo
        audioTutorialTocar.Stop();
        audioTutorialRotar.Play();
        mapa.GetComponent<RotarMapa>().enabled = true;
        instrucciones.text = "Toca una puerta o un filtro";
        
        
    }

   
}
