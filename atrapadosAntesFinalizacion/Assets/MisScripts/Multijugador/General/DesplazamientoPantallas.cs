using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DesplazamientoPantallas : MonoBehaviour
{
    /* Se encarga de el desplazamiento en el canvas
     * de elegir jugador. Habilita y deshabilita elementos
     * según los botones que se presionan. 
     */
    //Botón de Héctor 1
    public Button primerHector;
    public Button laura;
    public Button julian;
    //Botón de Héctor 2
    public Button segundoHector;
    //Botón de elegir 1
    public Button elegirLaura;
    //Botón de elegir 2
    public Button elegirHector;
    //Botón de elegir 3
    public Button elegirJulian;
    [SerializeField]
    private Text nombrePersonaje;
    [SerializeField]
    private Image imagen;
    [SerializeField]
    private Sprite imagenLaura;
    [SerializeField]
    private Sprite imagenJulian;
    [SerializeField]
    private Sprite imagenHector;
    
    /* Este script se encarga de activar los elementos 
     * para elegir y visualizar al personaje de Laura. 
     * Está en el OnClick del botón Laura. 
     */
    public void irPantallaLaura()
    {
        //Botones
        laura.gameObject.SetActive(false);
        primerHector.gameObject.SetActive(true);
        julian.gameObject.SetActive(false);
        segundoHector.gameObject.SetActive(false);
        elegirLaura.gameObject.SetActive(true);
        elegirHector.gameObject.SetActive(false);
        elegirJulian.gameObject.SetActive(false);
        //Nombre
        nombrePersonaje.text = "Laura";
        //Imagen
        imagen.GetComponent<Image>().sprite = imagenLaura;
        
    }
    /* Este script se encarga de activar los elementos 
    *  para elegir y visualizar al personaje de Héctor. 
    *  Está en el OnClick del botón Héctor. 
    */
    public void irPantallaHector()
    {
        //Botones
        laura.gameObject.SetActive(true);
        primerHector.gameObject.SetActive(false);
        julian.gameObject.SetActive(true);
        segundoHector.gameObject.SetActive(false);
        elegirLaura.gameObject.SetActive(false);
        elegirHector.gameObject.SetActive(true);
        elegirJulian.gameObject.SetActive(false);
        //Nombre
        nombrePersonaje.text = "Héctor";
        //Imagen
        imagen.GetComponent<Image>().sprite = imagenHector;
    }

    /* Este script se encarga de activar los elementos 
    *  para elegir y visualizar al personaje de Julián. 
    *  Está en el OnClick del botón Julián. 
    */
    public void irPantallaJulian()
    {
        //Botones
        laura.gameObject.SetActive(false);
        primerHector.gameObject.SetActive(false);
        julian.gameObject.SetActive(false);
        segundoHector.gameObject.SetActive(true);
        elegirLaura.gameObject.SetActive(false);
        elegirHector.gameObject.SetActive(false);
        elegirJulian.gameObject.SetActive(true);
        //Nombre
        nombrePersonaje.text = "Julián";
        //Imagen
        imagen.GetComponent<Image>().sprite = imagenJulian;
    }

}
//IR AL SCRIPT AdministradorCanvasJugadores.cs
