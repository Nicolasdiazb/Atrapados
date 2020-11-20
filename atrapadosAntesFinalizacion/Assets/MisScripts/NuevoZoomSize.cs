using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevoZoomSize : MonoBehaviour
{
 public GameObject mapa;
    // Update is called once per frame
    void Update()
    {
         if (Input.touchCount == 2)
        {
            // Guardarlos como variables para hacer cositas con ellos
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touch0Original = touch0.position - touch0.deltaPosition;
            Vector2 touch1Original = touch1.position - touch1.deltaPosition;

            float MagnitudTouchOriginal = (touch0Original - touch1Original).magnitude;
            float MagnitudTouchDelta = (touch0.position - touch1.position).magnitude;

            // Esto encuentra la distancia entre los toques anteriores al actual
            float MagnitudDistancia = MagnitudTouchOriginal - MagnitudTouchDelta;

            float apretacion = MagnitudDistancia * 0.02f * Time.deltaTime;
            mapa.transform.localScale += new Vector3(apretacion, apretacion, apretacion);


        }
    }
}
