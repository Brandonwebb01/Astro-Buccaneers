using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    [SerializeField] int health = 50;


    private EnemySpawner enemySpawner;

    void Start() {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void OnTriggerEnter2D(Collider2D other)
{
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
        Destroy(gameObject);
        enemySpawner.OnEnemyShipDestroyed(enemyShipName);
    }
}
}
