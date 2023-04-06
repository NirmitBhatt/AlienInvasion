using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectiles : MonoBehaviour
{
    [SerializeField] private Transform firePoint1;
    [SerializeField] private Transform firePoint2;
    [SerializeField] private Transform firePoint3;
    [SerializeField] private Transform firePoint4;
    public GameObject carbonProjectilePrefab;
    private bool canProjectileShoot = true;

    [SerializeField] private float projectileForce = 0.5f;
    [SerializeField] private float projectileSpawnTime = 5f;

    private void Start()
    {
        StartCoroutine(EmitProjectile());
    }


    private IEnumerator EmitProjectile()
    {
        while(canProjectileShoot)
        {
            yield return new WaitForSeconds(projectileSpawnTime);
            GameObject projectile1 = Instantiate(carbonProjectilePrefab, firePoint1.position, firePoint1.rotation);
            Rigidbody2D rb1 = projectile1.GetComponent<Rigidbody2D>();
            rb1.AddForce(firePoint1.up * projectileForce, ForceMode2D.Impulse);

            GameObject projectile2 = Instantiate(carbonProjectilePrefab, firePoint2.position, firePoint2.rotation);
            Rigidbody2D rb2 = projectile2.GetComponent<Rigidbody2D>();
            rb2.AddForce(firePoint2.up * projectileForce, ForceMode2D.Impulse);

            GameObject projectile3 = Instantiate(carbonProjectilePrefab, firePoint3.position, firePoint3.rotation);
            Rigidbody2D rb3 = projectile3.GetComponent<Rigidbody2D>();
            rb3.AddForce(firePoint3.up * projectileForce, ForceMode2D.Impulse);

            GameObject projectile4 = Instantiate(carbonProjectilePrefab, firePoint4.position, firePoint4.rotation);
            Rigidbody2D rb4 = projectile4.GetComponent<Rigidbody2D>();
            rb4.AddForce(firePoint4.up * projectileForce, ForceMode2D.Impulse);
        }
        
    }
}
