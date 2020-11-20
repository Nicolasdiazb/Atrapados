using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARTimer : MonoBehaviour
{
    public Sprite est1;
    public Sprite est2;
    public Sprite est3;
    void Start()
    {
        InvokeRepeating("ReiniciarVariables", 30.0f, 30.0f);
        InvokeRepeating("CambiarAnimacion", 1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReiniciarVariables()
    {
        gameObject.GetComponent<ARMic>().contadorMic = 0;
        gameObject.GetComponent<ARMic>().numero.text = gameObject.GetComponent<ARMic>().contadorMic.ToString();
    }
   
}
