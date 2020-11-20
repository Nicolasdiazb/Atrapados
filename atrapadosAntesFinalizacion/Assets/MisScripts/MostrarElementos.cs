using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarElementos : MonoBehaviour
{

    [SerializeField]
    private GameObject bienvenida;
    // Start is called before the first frame update
    [SerializeField]
    private GameObject botonesExternos;
   
    [SerializeField]
    private GameObject hud;
    [SerializeField]
    private GameObject canvasHud;
   
    public void continuarExperiencia()
    {
        bienvenida.SetActive(false);
        botonesExternos.SetActive(true);
        canvasHud.SetActive(true);
        hud.SetActive(true);

    }
}
