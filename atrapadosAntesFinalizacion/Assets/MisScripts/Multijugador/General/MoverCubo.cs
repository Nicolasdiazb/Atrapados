using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCubo : MonoBehaviour
{
    // Start is called before the first frame update
    private float velocidadMovimiento;
    public GameObject objetoMover;
    void Start()
    {
        velocidadMovimiento = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidadMovimiento * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, velocidadMovimiento * Input.GetAxis("Vertical") * Time.deltaTime);
        Debug.Log("Resultado Mapeo Z: " + mapearPosicion(transform.localPosition.z, 0, 19.04f, 0, 8.78f, 8.78f));
        Debug.Log("Resultado Mapeo X: " + mapearPosicion(transform.localPosition.x, -4.45f, 4.38f, -15.13f, -9.88f, -9.85f));
        float posicionZ = mapearPosicion(transform.localPosition.z, 0, 19.04f, 0, 8.78f, 8.78f);
        float posicionX = mapearPosicion(transform.localPosition.x, -4.45f, 4.38f, -15.13f, -9.88f, -9.85f);
        objetoMover.GetComponent<MoverMapeo>().moverMapeo(transform.position, posicionX, posicionZ);
        Debug.Log("Pos en z: " + transform.localPosition.z);

    }

    //posicion a mapear, inicioGrande, finalGrande, inicioPequeño, finalPequeño, limite
    public float mapearPosicion(float n, float start1, float stop1, float start2, float stop2, float limites)
    {
        float valorNuevo = (n - start1) / (stop1 - start1) * (stop2 - start2) + start2;
        if (valorNuevo  != limites)
        {
            return valorNuevo;
        }
        if (start2 < stop2)
        {
            return Constrain(valorNuevo, start2, stop2);
        }
        else
        {
            return Constrain(valorNuevo, stop2, start2);
        }
    }

    public float Constrain(float n, float low, float high)
    {

        return Mathf.Max(Mathf.Min(n, high), low);
    }
    
}
