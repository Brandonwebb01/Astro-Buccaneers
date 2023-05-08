using UnityEngine;

public class EnemyShipLogic : MonoBehaviour
{
    public float patrolRadius = 200f;
    public Transform player;
    public float chaseRange = 4f;
    public float moveSpeed = 3f;
    public float chaseSpeed = 5f;
    public float xLimit = 10f;
    public float yLimit = 10f;

    private Vector2 patrolCenter;
    private float patrolAngle;
    private bool chasingPlayer = false;

    void Start()
    {
        patrolCenter = transform.position;
        patrolAngle = Random.Range(0f, 360f);
    }

    void Update()
    {
        if (player != null)
        {
            // calculate distance to player
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer < chaseRange)
            {
                // if player is within chase range, start chasing them
                chasingPlayer = true;
            }
            else if (chasingPlayer)
            {
                // if ship was chasing player but player has moved out of range, return to patrolling
                chasingPlayer = false;
            }
        }

        // calculate next position along patrol circle
        float angleRadians = patrolAngle * Mathf.Deg2Rad;
        Vector2 nextPatrolPosition = new Vector2(Mathf.Sin(angleRadians), Mathf.Cos(angleRadians)) * patrolRadius + patrolCenter;

        // move towards next patrol position or player if chasing
        Vector2 targetPoint = chasingPlayer ? player.position : nextPatrolPosition;
        float speed = chasingPlayer ? chaseSpeed : moveSpeed;

        // limit the target point to the x and y limits
        targetPoint.x = Mathf.Clamp(targetPoint.x, -xLimit, xLimit);
        targetPoint.y = Mathf.Clamp(targetPoint.y, -yLimit, yLimit);

        transform.position = Vector2.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);

        // update patrol angle
        patrolAngle += 0.04f;

        // wrap patrol angle to 0-360 range
        if (patrolAngle > 360f)
        {
            patrolAngle -= 360f;
        }
    }
}