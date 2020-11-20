using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminCamara : MonoBehaviour
{
 public Transform posInicial;
    Transform selectedScreen;
    public Camera camara;
    private bool touchingScreen;
    private bool activado;
    private bool once = false;
    public GameObject controladorCamaras;
    

    //Se crea un objeto de tipo "ManejoCamaras".
    ManejoCamara manejoCamara;

    // Use this for initialization
    void Start()
    {
        //Se instancia un objeto de tipo "ManejoCamaras".
        manejoCamara = controladorCamaras.GetComponent<ManejoCamara>();
        //camara = transform.Find("camPC").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastMouse();
        OnScreenClick();
        VolverAPosInicial();
    }

    //El raycast del mouse para tocar las pantallas.
    void RaycastMouse()
    {
        RaycastHit hit;
        Ray ray = camara.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            if (objectHit.tag == "pantalla")
            {
                touchingScreen = true;
                selectedScreen = objectHit;

            }
            else
            {
                touchingScreen = false;
            }
        }
    }

    //Cuando se le da click a cualquiera de las pantallas.
    void OnScreenClick()
    {
        if (touchingScreen && Input.GetMouseButtonDown(0) && once == false)
        {
            //Aqui se toma el nombre de la pantalla y se le separa, esto para obtener su numero y poder manipular la camara adecuada.
            //Para agregar una nueva pantalla al juego, se le debe nombrar Pantalla_4 (el numero maximo de pantallas).
            string[] partes = selectedScreen.name.Split('_');
            int indice = int.Parse(partes[1]);

            //Aqui se llama la funcion "ManejarCamaras()" del script "ManejoCamaras".
            manejoCamara.ManejarCamaras(indice);

            //Aqui se ubica al jugador al frente de la pantalla seleccionada.
            transform.position = new Vector3(selectedScreen.position.x - 2f, selectedScreen.position.y, selectedScreen.position.z);
            once = true;
        }
        
    }

    //Cuando se esta mirando (manipulando) una pantalla y se quiere devolver a la vista general de todas las pantallas.
    void VolverAPosInicial()
    {
        if (transform.position != posInicial.position && Input.GetKeyDown(KeyCode.S) && once == true)
        {
            Debug.Log("volviendo a la posicion inicial");

            //Se devuelve a la vista general de pantallas.
            transform.position = posInicial.position;
            once = false;

            //Se desactiva la manipulacion de las camaras por medio de la funcion "CancelarManejos()" del script "ManejoCamaras".
            manejoCamara.CancelarManejos();
        }
    }
}
