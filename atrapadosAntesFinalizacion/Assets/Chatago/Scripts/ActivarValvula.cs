using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Photon.Pun;

public class ActivarValvula : MonoBehaviour
{
    [SerializeField]

    public Valvula[] misValvulas;
    [SerializeField]
   
    private Camera camaraPC;
    private Vector2 toquePosicion = default;
    private bool sirve;
    public bool activado;
    //private PhotonView PhotonV;

        //Para activar los elementos de Photon se deben descomentar las líneas: 4, 20, 24 y 85
        //También el método de la línea 92 a la 96
   
        void Start()
        {
            //PhotonV = GetComponent<PhotonView>();
        }


        void Update()
        {


            RaycastHit hit;
            Ray ray = camaraPC.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //Intentar encontrar el script
                Valvula misValvulas = hit.transform.GetComponent<Valvula>();

                if (Input.GetMouseButtonDown(0) && misValvulas != null)
                {
                    encender(misValvulas);
                    sirve = true;
                }
                else
                {
                    sirve = false;

                }
            }
        }



        void encender(Valvula elegida)
        {

            foreach (Valvula a in misValvulas)
            {
                bool activado = a.GetComponent<Valvula>().encendido;
                //GameObject justInCase = a.GetComponent<Valvula>().Indicador;
                GameObject particulas = a.GetComponent<Valvula>().Particulas;
                if (elegida == a)
                {
                    if (activado == false)
                    {
                        Debug.Log("ugh");
                        //justInCase.GetComponent<Collider>().enabled=false;
                        particulas.SetActive(true);
                        activado = true;
                        a.cambio();


                    }
                    else if (activado == true)
                    {
                        //justInCase.GetComponent<Collider>().enabled=true;
                        particulas.SetActive(false);
                        activado = false;
                        a.cambio();


                    }

                    a.IsSelected = true;
                }
                else
                {

                    a.IsSelected = false;
                }
                //PhotonV.RPC("RPC_Actualizar", RpcTarget.Others, activado);

            }


        }

        /*[PunRPC]
          void RPC_Actualizar(bool valorEncendido){
                activado = valorEncendido;
                Debug.Log("Ayuda");
            }*/
    }
