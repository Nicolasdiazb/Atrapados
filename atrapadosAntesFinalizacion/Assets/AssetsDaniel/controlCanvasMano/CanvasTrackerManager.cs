using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CanvasTrackerManager : MonoBehaviour
{
    public GameObject canvasPrefab;
    public CanvasEvent OnHandTouched;
    bool isTouched;
    public Vector3 CanvasOffset;
    VirtualHand[] hands;

    public float DistanceBetweenHands;
    public void Start()
    {
        hands = FindObjectsOfType<VirtualHand>();
        hands.ToList().ForEach(h =>
        {
            OnHandTouched.AddListener((GameObject _canvasPrefab, Vector3 _offset) => h.OnCanvasEvent(_canvasPrefab, _offset));
        });
        StartCoroutine(CheckForHandsTouch());
    }

    private IEnumerator CheckForHandsTouch()
    {
        if (!isTouched)
        {
            if (Vector3.Distance(hands[0].transform.position, hands[1].transform.position) < DistanceBetweenHands)
            {
                OnHandTouched.Invoke(canvasPrefab,CanvasOffset);
                isTouched = true;
                StartCoroutine(CheckForHandsLeftTouch());
                //StopCoroutine("CheckForHandsTouch");
            }
            else
            {
                yield return new WaitForSeconds(0.2f);
                StartCoroutine(CheckForHandsTouch());
            }
        }

    }


    private IEnumerator CheckForHandsLeftTouch()
    {
        if (isTouched)
        {
            if (Vector3.Distance(hands[0].transform.position, hands[1].transform.position) > DistanceBetweenHands)
            {
                OnHandTouched.Invoke(canvasPrefab,CanvasOffset);
                isTouched = false;
                StartCoroutine(CheckForHandsTouch());
                //StopCoroutine("CheckForHandsLeftTouch");
            }
            else
            {
                yield return new WaitForSeconds(0.2f);
                StartCoroutine(CheckForHandsLeftTouch());
            }
        }

    }
}
