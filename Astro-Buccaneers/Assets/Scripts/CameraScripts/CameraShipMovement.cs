using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraScripts
{
    public class CameraShipMovement : MonoBehaviour
    {
        public Transform playerTransform;
        public Vector3 cameraOffset;
        public float followSpeed = 5.0f;

        private void LateUpdate()
        {
            // Check if the playerTransform reference is set
            if (playerTransform != null)
            {
                // Calculate the desired position of the camera
                Vector3 desiredPosition = playerTransform.position + cameraOffset;

                // Use Lerp to smoothly move the camera towards the desired position
                transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
            }
        }
    }
}
