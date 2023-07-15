using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ShipBattleScripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] float speed = 5f;
        [SerializeField] float paddingLeft;
        [SerializeField] float paddingRight;
        [SerializeField] float paddingTop;
        [SerializeField] float paddingBottom;

        Shoot shoot;

        Vector2 rawInput;
        Vector2 minBounds;
        Vector2 maxBounds;

        ShipHealth shipHealth;

        void Start()
        {
            InitBounds();
            shipHealth = GetComponent<ShipHealth>(); // Get reference to the ShipHealth component
        }

        void Update()
        {
            if (shipHealth.GetHealth() > 0) // Check if health is greater than zero
            {
                Move();
            }
        }

        void Awake()
        {
            shoot = GetComponent<Shoot>();
        }

        void InitBounds()
        {
            Camera mainCamera = Camera.main;
            minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
            maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
        }

        void Move()
        {
            Vector2 delta = rawInput * speed * Time.deltaTime;
            Vector2 newPos = new Vector2();
            newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
            newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
            transform.position = newPos;
        }

        void OnMove(InputValue value)
        {
            rawInput = value.Get<Vector2>();
        }

        void OnFire(InputValue value)
        {
            if (shoot != null)
            {
                shoot.isFiring = value.isPressed;
            }
        }
    }
}