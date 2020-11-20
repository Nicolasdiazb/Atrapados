using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverMapeo : MonoBehaviour
{
    // Start is called before the first frame update
    private float velocidadMovimiento;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moverMapeo(Vector3 posCubo, float posX, float posZ)
    {
      transform.localPosition = new Vector3(posX, 13.936f, posZ);
      
    }
}
