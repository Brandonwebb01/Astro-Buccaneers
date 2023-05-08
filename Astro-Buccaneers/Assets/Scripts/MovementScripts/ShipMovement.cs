using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 180f; // The speed at which the ship rotates
    public float xLimit = 10f;
    public float yLimit = 10f;

    private Rigidbody2D rb;
    private Vector2 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.Rotate(0, 0, -horizontal * rotationSpeed * Time.deltaTime);

        Vector2 movement = new Vector2(0, vertical);
        movement = transform.TransformDirection(movement); // Apply the rotation to the movement vector
        targetPosition += movement * speed * Time.deltaTime;

        // limit the target position to the x and y limits
        targetPosition.x = Mathf.Clamp(targetPosition.x, -xLimit, xLimit);
        targetPosition.y = Mathf.Clamp(targetPosition.y, -yLimit, yLimit);

        // Lerp between the current position and the target position
        transform.position = Vector2.Lerp(transform.position, targetPosition, 0.5f);
    }
}
