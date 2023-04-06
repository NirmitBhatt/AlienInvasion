using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public float lifeTime = 1f;
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(!(collision.collider.CompareTag("Player") || collision.collider.CompareTag("Bullet")))
    //    {
    //        Destroy(gameObject);
    //    }
    //    if (collision.collider.CompareTag("Enemy"))
    //    {
    //        //Give Damage to Enemy.
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!(collider.CompareTag("Player") || collider.CompareTag("Bullet")))
        {
            Destroy(gameObject);
        }
        if (collider.CompareTag("Enemy"))
        {
            //Give Damage to Enemy.
        }
    }

    void Update()
    {
        Destroy(gameObject, lifeTime);
    }
}
