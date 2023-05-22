using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBattleMovement : MonoBehaviour
{
    public float speed = 5f;
    public float xLimit = 10f;
    public float yLimitOffset = 5f;
    public float minY = -6.0f;
    public float maxY = 6.0f;

    private Rigidbody2D rb;
    private Vector2 targetPosition;
    private float yLimit;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;

        // set the y limit based on the position of the ship
        yLimit = transform.position.y + yLimitOffset;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // move the ship horizontally and vertically
        targetPosition.x += horizontal * speed * Time.deltaTime;
        targetPosition.y += vertical * speed * Time.deltaTime;

        // limit the target position to the x and y limits
        targetPosition.x = Mathf.Clamp(targetPosition.x, -xLimit, xLimit);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        // update the position of the ship
        transform.position = targetPosition;
    }
}