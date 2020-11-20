using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverCamPCChatago : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public Sprite bloqueado;
    public Sprite desbloqueado;

    public Image cursor;

    //public Vector3 offset;
    private Vector3 mousePosition;

    public Camera camPC;

    [SerializeField]
    private bool locker = true;
    
    void Start()
    {
        
        //Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
    	yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
     

    }

   


    
}
