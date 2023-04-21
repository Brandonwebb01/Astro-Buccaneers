using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 5.0f;

    public float cameraMinX = -10f;
    public float cameraMaxX = 5f;
    public float cameraMinY = -10f;
    public float cameraMaxY = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            // Get the camera's current position
        Vector3 cameraPosition = transform.position;
        
        // Restrict the camera's X position within the specified range
        cameraPosition.x = Mathf.Clamp(cameraPosition.x, cameraMinX, cameraMaxX);
        
        // Restrict the camera's Y position within the specified range
        cameraPosition.y = Mathf.Clamp(cameraPosition.y, cameraMinY, cameraMaxY);
        
        // Set the camera's new position
        transform.position = cameraPosition;

         if(Input.GetKey(KeyCode.RightArrow))
     {
         transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
     }
     if(Input.GetKey(KeyCode.LeftArrow))
     {
         transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
     }
     if(Input.GetKey(KeyCode.DownArrow))
     {
         transform.Translate(new Vector3(0,-speed * Time.deltaTime,0));
     }
     if(Input.GetKey(KeyCode.UpArrow))
     {
         transform.Translate(new Vector3(0,speed * Time.deltaTime,0));
     }
    }
}
