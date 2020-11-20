using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcercarMapa : MonoBehaviour
{
    // Start is called before the first frame update
    float distanciaInicial;
    float velocidadZoom = 1.0f;
    [SerializeField]
    private Camera camaraAR;
    public GameObject mapa;
    private Vector3 scaleChange;
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 2 && (Input.GetTouch(0).phase == TouchPhase.Began ||
        Input.GetTouch(1).phase == TouchPhase.Began ))
        {
            distanciaInicial = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
            scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
        }
        else if(Input.touchCount == 2 && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved))
        {
            float distancia;
            Vector2 toque1 = Input.GetTouch(0).position;
            Vector2 toque2 = Input.GetTouch(1).position;

            distancia = Vector2.Distance(toque1, toque2);

            float pinchAmount = (distanciaInicial - distancia) * velocidadZoom * Time.deltaTime;

            mapa.transform.localScale += scaleChange;

            distanciaInicial = distancia;

        }
    }
}
