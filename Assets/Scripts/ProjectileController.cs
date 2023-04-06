using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    private void Update()
    {
        if (transform.position.x < -14 || transform.position.x > 14 || transform.position.y < -8 || transform.position.y > 8)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") || collider.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
