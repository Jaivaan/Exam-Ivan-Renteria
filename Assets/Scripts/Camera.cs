using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    public Vector3 offset = new Vector3(0f, 2f, -5f); 

    private float currentYaw = 0f; 
    private float currentPitch = 0f;
    public float mouseSensitivity = 3f; 
    public float pitchRange = 45f; 


    void Start()
    {
        Cursor.visible = false;

    }

    private void LateUpdate()
    {
        currentYaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        currentPitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        currentPitch = Mathf.Clamp(currentPitch, -pitchRange, pitchRange);

        Vector3 rotatedOffset = Quaternion.Euler(currentPitch, currentYaw, 0) * offset;

        transform.position = target.position + rotatedOffset;

        transform.LookAt(target);

        target.eulerAngles = new Vector3(0f, currentYaw, 0f);
    }
}
