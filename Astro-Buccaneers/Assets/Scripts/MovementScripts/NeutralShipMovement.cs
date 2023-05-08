using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralShipMovement : MonoBehaviour
{
    public float speed = 10f;
    public float xLimit = 10f;
    public float yLimit = 10f;
    public float radius = 5f;

    private float angle;

    private void Start()
    {
        // Set the angle to a random value between 0 and 360 degrees
        angle = Random.Range(0f, 360f);
    }

    private void Update()
    {
        // Move the spaceship horizontally
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // If the spaceship goes beyond the x limit, move it to the other side
        if (transform.position.x > xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }

        // If the spaceship goes beyond the y limit, move it to the other side
        if (transform.position.y > yLimit)
        {
            transform.position = new Vector3(transform.position.x, -yLimit, transform.position.z);
        }

        // Calculate the new position of the spaceship
        float x = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
        float y = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        Vector3 newPosition = new Vector3(x, y, 0f);

        // Debug.Log(newPosition); // Uncomment this line to see the new position

        // Move the spaceship to the new position
        transform.position = newPosition;

        // Increase the angle for the next frame
        angle += speed * Time.deltaTime;
    }
}