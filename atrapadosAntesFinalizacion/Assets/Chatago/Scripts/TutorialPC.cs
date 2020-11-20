using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPC : MonoBehaviour
{
	public AudioSource fuente;
	public AudioClip uno;
	public AudioClip dos;
	public AudioClip tres;
	public AudioClip cuatro;
	public AudioClip cinco;
	public GameObject valvula;
	public GameObject screen;
	public Material change;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(empezar());
    }

    // Update is called once per frame
    void Update()
    {
    }

IEnumerator empezar(){
	yield return new WaitForSeconds(5);

	fuente.clip = uno;
	fuente.Play();
	StartCoroutine(audio1());


}
     IEnumerator audio1()
    {
        
		yield return new WaitForSeconds(17);
        // Start function WaitAndPrint as a coroutine
        
        fuente.clip = dos;
        fuente.Play();
        StartCoroutine(audio2());
        StartCoroutine(selecScreen());

    }


    IEnumerator audio2(){
    	yield return new WaitForSeconds(17);

    	fuente.clip = tres;
    	fuente.Play();
    	
    	StartCoroutine(audio3());
    	StartCoroutine(selecValve());
    	}
    

    IEnumerator audio3(){
    	yield return new WaitForSeconds(10);

		fuente.clip = cuatro;
		fuente.Play();
		StartCoroutine(audio4());
		
    } 

    IEnumerator audio4(){

    	yield return new WaitForSeconds(10);
    	fuente.clip = cinco;
    	fuente.Play();
    }

    IEnumerator selecScreen(){
    	yield return new WaitForSeconds(6);
    	screen.GetComponent<Renderer>().material = change;
    }

    IEnumerator selecValve(){
    	yield return new WaitForSeconds(7);
    	valvula.GetComponent<Renderer>().material = change;
    }
}
