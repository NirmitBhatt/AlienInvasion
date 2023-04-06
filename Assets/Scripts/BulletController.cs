using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float lifeTime = 1f;
    [SerializeField] private Rigidbody2D rb;
    //private void Start()
    //{
    //    GameHelper.SharedInstance.DoSomethingAfterXSeconds(ReturnToPool, lifeTime);
    //}

    private void Update()
    {
        if(transform.position.x < -14 || transform.position.x > 14 || transform.position.y < -8 || transform.position.y > 8)
        {
            ReturnToPool(); 
        }
    }
    private void ReturnToPool()
    {
        gameObject.SetActive(false);
    }

    public void Shoot(Vector2 direction, float shootForce)
    {
        rb.AddForce(direction * shootForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!(collider.CompareTag("Player") || collider.CompareTag("Bullet")))
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
        if (collider.CompareTag("Enemy"))
        {
            //Give Damage to Enemy.
        }
    }
}
