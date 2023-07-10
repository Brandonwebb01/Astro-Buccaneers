using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    [SerializeField] int health = 50;

    public float destroyDelay = 0.5f; // Lowered destroy delay value

    private EnemySpawner enemySpawner;
    private Animator animator;

    private bool isDestroyed = false;

    void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        animator = GetComponent<Animator>();
        animator.enabled = false; // Disable the animator initially
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDestroyed) return; // Skip processing if already destroyed

        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            string enemyShipName = gameObject.name;
            animator.enabled = true; // Enable the animator before triggering the animation
            animator.SetTrigger("Destroy");
            enemySpawner.OnEnemyShipDestroyed(enemyShipName);

            StartCoroutine(DestroyAfterAnimation(enemyShipName));
        }
    }

    IEnumerator DestroyAfterAnimation(string enemyShipName)
    {
        isDestroyed = true; // Mark as destroyed to prevent further damage

        // Wait until the current animation finishes playing
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationLength + destroyDelay);

        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return health;
    }
}
