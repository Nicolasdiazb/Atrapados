using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VirtualHand : MonoBehaviour
{
    public bool trackCanvasOnHand;
    bool isCanvasActive;
    bool initialized;
    GameObject canvas;
    Vector3 currOffset;
    public void OnCanvasEvent(GameObject _canvasPrefab, Vector3 _offset)
    {
        if (trackCanvasOnHand)
        {
            if (initialized)
            {
                if (!isCanvasActive)
                {
                    canvas.SetActive(true);
                    isCanvasActive = true;
                }
                else
                {
                    isCanvasActive = false;
                    canvas.SetActive(false);
                }
            }
            else
            {
                Init(_canvasPrefab, _offset);
            }
        }
    }

    private void Init(GameObject _canvas, Vector3 _offset)
    {
        if (canvas)
            Destroy(canvas.gameObject);
        canvas = Instantiate(_canvas, transform.position + _offset, transform.rotation, transform);
        currOffset = _offset;
        isCanvasActive = true;
        initialized = true;
        SessionDataScript.Usuario = canvas.name;
    }
}
