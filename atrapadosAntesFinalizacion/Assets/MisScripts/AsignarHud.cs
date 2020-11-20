using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AsignarHud : MonoBehaviour
{
    // Start is called before the first frame update
    public Text valorHud;
    int numero;
    void Start()
    {
        numero = Random.Range(80, 100);
        valorHud.text = numero.ToString() + "%";
        StartCoroutine(CorrutinaValor());
    }

    // Update is called once per frame

    IEnumerator CorrutinaValor()
    {
        yield return new WaitForSeconds(5);
        numero = Random.Range(80, 100);
        valorHud.text = numero.ToString() + "%";
        StartCoroutine(CorrutinaValor());
    }

}
