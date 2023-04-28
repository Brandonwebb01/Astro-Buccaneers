using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTransform;
    public float speed = 5.0f;

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
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}