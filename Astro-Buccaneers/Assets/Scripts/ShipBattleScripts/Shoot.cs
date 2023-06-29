using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float bulletLifeTime = 2f;
    [SerializeField] float fireRate = 0.2f;
    [SerializeField] bool useAI;

    public bool isFiring;

    Coroutine firingCoroutine;

    void Start() {
        if (useAI) {
            isFiring = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire() {
        if (isFiring && firingCoroutine == null) {
            firingCoroutine = StartCoroutine(FireContinuously());
        } else if (!isFiring && firingCoroutine != null) {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously() {
        while(true) {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * bulletSpeed;
            }
            Destroy(bullet, bulletLifeTime);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
