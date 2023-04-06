using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    private float enemyHealth = 40f;
    private float maxHealth;
    [SerializeField] private float damage = 10f;
    [SerializeField] private ParticleSystem explosionEffect;
    public HealthBarBehaviour healthbar;
    private GameObject firePowerUp;
    private GameObject waterPowerUp;
    private GameObject carbonPowerUp;
    [SerializeField] private GameObject armour;

    [SerializeField] private Color minColor;
    [SerializeField] private Color maxColor;

    private void Start()
    {
        firePowerUp = Resources.Load("Fire") as GameObject;
        waterPowerUp = Resources.Load("Water") as GameObject;
        carbonPowerUp = Resources.Load("Carbon") as GameObject;
        maxHealth = enemyHealth;
        healthbar.SetHealth(enemyHealth, maxHealth);
    }

    private void Update()
    {
        //Debug.Log("Carbon's health: " + enemyHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            enemyHealth -= damage;
            healthbar.SetHealth(enemyHealth, maxHealth);
            if (enemyHealth <= 0)
            {
                ParticleSystem explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                ParticleSystem.MainModule mainModule = explosion.main;
                mainModule.startColor = new ParticleSystem.MinMaxGradient(minColor, maxColor);
                explosion.Play();
                Destroy(explosion.gameObject, .7f);
                if(gameObject.CompareTag("FirePowerUp"))
                {
                    Instantiate(firePowerUp, transform.position, Quaternion.identity);
                }
                if(gameObject.CompareTag("WaterPowerUp"))
                {
                    Instantiate(waterPowerUp, transform.position, Quaternion.identity);
                }
                if(gameObject.CompareTag("CarbonPowerUp"))
                {
                    Instantiate(carbonPowerUp, transform.position, Quaternion.identity);
                }
                //if(gameObject.CompareTag("AmrourFire"))
                //{
                //    Instantiate(armour, transform.position, Quaternion.identity);
                //}
                //if (gameObject.CompareTag("AmrourWater"))
                //{
                //    Instantiate(armour, transform.position, Quaternion.identity);
                //}
                //if (gameObject.CompareTag("AmrourCarbon"))
                //{
                //    Instantiate(armour, transform.position, Quaternion.identity);
                //}
                Destroy(gameObject);
            }
        }
    }
}
