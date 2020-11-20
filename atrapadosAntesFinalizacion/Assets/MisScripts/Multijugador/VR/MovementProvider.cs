using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class MovementProvider : LocomotionProvider
{
    public float velocidad = 1.0f;
    public float gravityMultiplier = 1.0f;

    public List<XRController> controles = null;
    private CharacterController characterController = null;
    private GameObject head = null;

    public GameObject repJugadorAR;

    protected override void Awake()
    {
        characterController = GetComponent<CharacterController>();
        head = GetComponent<XRRig>().cameraGameObject;
    }
    void Start()
    {
        ControladorPosicion();
    }

    // Update is called once per frame
    void Update()
    {
        ControladorPosicion();
        ObtenerInput();
        //AplicarGravedad();
        //posicion a mapear, inicioGrande, finalGrande, inicioPequeño, finalPequeño, limite
        float posicionZ = mapearPosicion(transform.localPosition.z, -65.2f, 71.9f, -8.52f, 9.46f, 9.46f);
        float posicionX = mapearPosicion(transform.localPosition.x, -28.61f, 24.2f, -2.7f, 4.28f, 4.28f);
        repJugadorAR.GetComponent<MoverRep>().moverMapeo(posicionX, posicionZ);

    }
    private void ControladorPosicion()
    {
        //Espacio local para "head". Mover el prefab con la camara
        float alturaHead = Mathf.Clamp(head.transform.localPosition.y, 1, 2);
        characterController.height = alturaHead;
        //Mitad, skin
        Vector3 nuevoCentro = Vector3.zero;
        nuevoCentro.y = characterController.height / 2;
        nuevoCentro.y += characterController.skinWidth;

        //
        nuevoCentro.x = head.transform.localPosition.x;
        nuevoCentro.x = head.transform.localPosition.z;

        characterController.center = nuevoCentro;

    }

    private void ObtenerInput()
    {
        foreach(XRController controller in controles)
        {
            if (controller.enableInputActions)
            {
                ObtenerMovimiento(controller.inputDevice);
            }
               
        }
    }
    
    private void ObtenerMovimiento(InputDevice device)
    {
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
        {
            EmpezarMovimiento(position);
        }
    }
    private void EmpezarMovimiento(Vector2 position)
    {
        Vector3 direccion = new Vector3(position.x, 0, position.y);
        Vector3 rotacionCabeza = new Vector3(0, head.transform.eulerAngles.y, 0);

        direccion = Quaternion.Euler(rotacionCabeza) * direccion;

        Vector3 movimiento = direccion * velocidad;
        characterController.Move(movimiento * Time.deltaTime);

    }

    private void AplicarGravedad()
    {
        Vector3 gravedad = new Vector3(0, Physics.gravity.y * gravityMultiplier, 0);
        gravedad.y *= Time.deltaTime;

        characterController.Move(gravedad * Time.deltaTime);
    }

    public float mapearPosicion(float n, float start1, float stop1, float start2, float stop2, float limites)
    {
        float valorNuevo = (n - start1) / (stop1 - start1) * (stop2 - start2) + start2;
        if (valorNuevo != limites)
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
