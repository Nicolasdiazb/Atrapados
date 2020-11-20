using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFPSChatago : MonoBehaviour
{

	public float mouseS = 100f;

	public float rotorX = 100f;
	public Transform cam;
    // Start is called before the first frame update
    void Start()
    {     
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseS * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseS * Time.deltaTime;

        rotorX -= mouseY;
        rotorX = Mathf.Clamp(rotorX, 90f, 90f);

        transform.localRotation = Quaternion.Euler(rotorX, 0f, 0f);
        cam.Rotate(Vector3.up * mouseX);

    }
}
