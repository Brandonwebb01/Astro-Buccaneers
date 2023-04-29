using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 10.0f;

    public float cameraMinX = 0.1f;
    public float cameraMaxX = 15.5f;
    public float cameraMinY = 0.1f;
    public float cameraMaxY = 10.6f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Clamp(cameraPosition.x, cameraMinX, cameraMaxX);
        cameraPosition.y = Mathf.Clamp(cameraPosition.y, cameraMinY, cameraMaxY);
        transform.position = cameraPosition;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;
    }
}