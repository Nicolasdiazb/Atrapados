using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

[RequireComponent(typeof(ARTrackedImageManager))]
public class Experiencia : MonoBehaviour
{
    // Start is called before the first frame update
    /*[SerializeField]
    private GameObject botonesExternos;*/
    [SerializeField]
    private Text instrucciones;

    private ARTrackedImageManager trackedImageManager;

    Camera m_WorldSpaceCanvasCamera;

    public Camera worldSpaceCanvasCamera
    {
        get { return m_WorldSpaceCanvasCamera; }
        set { m_WorldSpaceCanvasCamera = value; }
    }


    void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
    }
    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }


    private void mostrarEntrada(ARTrackedImage trackedImage)
    {
        var canvas = trackedImage.GetComponentInChildren<Canvas>();
        canvas.worldCamera = worldSpaceCanvasCamera;

        if (trackedImage.trackingState == TrackingState.Tracking)
        {
            instrucciones.text = "Ahora sí";

        }
        else if(trackedImage.trackingState == TrackingState.None)
        {
            instrucciones.text = "Nada";
        }
    }
    // Update is called once per frame

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            // Give the initial image a reasonable default scale
           

            mostrarEntrada(trackedImage);
        }

        foreach (var trackedImage in eventArgs.updated)
            mostrarEntrada(trackedImage);
    }

}
