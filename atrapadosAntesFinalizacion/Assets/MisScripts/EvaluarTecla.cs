using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaluarTecla : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("tecla1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("tecla2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("tecla3");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            print("tecla4");
        }
    }
}
