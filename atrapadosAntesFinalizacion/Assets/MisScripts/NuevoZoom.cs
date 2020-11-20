using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevoZoom : MonoBehaviour
{
   
    public float velocidadZoomCamara = 0.2f;//Esta es la velocidad a la que va cambiar la distancia de la cámara
    public float velocidadZoomOrtografico = 0.2f;// Esto es lo mismo pero con la cámara ortográfica (La cámara AR no es ortográfica pero funcionó ¯\_(ツ)_/¯)

    [SerializeField]
    private Camera cam; //La cámara, ajá
 
 void Start()
 {
  cam = GetComponent<Camera>(); 
 }

    void Update()
    {
        // Si hay dos toques simultáneos en la pantalla
        if (Input.touchCount == 2)
        {
            // Guardarlos como variables para hacer cositas con ellos
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            // Esto encuentra la posición "Original" de los dedos antes de moverlos hacia cualquier lado
            Vector2 touch0Original = touch0.position - touch0.deltaPosition;
            Vector2 touch1Original = touch1.position - touch1.deltaPosition;

            // Esto guarda como magnitud la diferencia o distancia entre los dedos cada vez que cambien de posiciòn
            float MagnitudTouchOriginal = (touch0Original - touch1Original).magnitude;
            float MagnitudTouchDelta = (touch0.position - touch1.position).magnitude;

            // Esto encuentra la distancia entre los toques anteriores al actual
            float MagnitudDistancia = MagnitudTouchOriginal - MagnitudTouchDelta;

            // Esto busca si la cámara es ortográfica (No es pero pues si toca, toca)
            if (cam.orthographic)
            {
            	//Esto no lo entendí bien, pero sin eso, no sirve... :D
                cam.orthographicSize += MagnitudDistancia * velocidadZoomOrtografico;

                
                cam.orthographicSize = Mathf.Max(cam.orthographicSize, 0.1f);
            }
            else
            {
                //Con esto la cámara viaja hacia el frente o hacia atrás dependiendo de la distancia actual de los dedos con respecto
                //A la posición original en la que estaban
                cam.transform.position -= transform.forward * (MagnitudDistancia/1020) / (velocidadZoomCamara/2);
            }
           
        }
        /*
         if (Input.GetKeyDown("space"))
        {
            cam.transform.Translate(1,1,1);
        }

        if (Input.GetKeyDown("backspace"))
        {
        	cam.transform.Translate(-1,-1,-1);
        }
        */
    }


}