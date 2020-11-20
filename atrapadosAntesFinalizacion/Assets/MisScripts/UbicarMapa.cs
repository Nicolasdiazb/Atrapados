using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UbicarMapa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Guia"))
        {
            transform.position = new Vector3(GameObject.FindGameObjectWithTag("Guia").transform.position.x, GameObject.FindGameObjectWithTag("Guia").transform.position.y, GameObject.FindGameObjectWithTag("Guia").transform.position.z);
        }
        else
        {

        }
    }
}
