using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Vector2 movement;
    [SerializeField] private bool isMoving;

    [SerializeField] private Vector2 mousePos;
    [SerializeField] private Camera cam;

    [SerializeField] private BulletController bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireForce;
    [SerializeField] private bool canShoot = true;
    [SerializeField] private float SHOOT_INTERVAL = 2;
    [SerializeField] private float currentShootGap = 0;

    [SerializeField] private bool canDash = true;
    [SerializeField] private bool isDashing;
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 4;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 4;
    }
    private void Update()
    {
        HandleShootTimer();
        HandlePlayerInput();
        HandlePlayerRotation();
    }

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, (screenBounds.x - 1) * -1 - objectWidth, (screenBounds.x - 1) + objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, (screenBounds.y - 1) * -1 - objectHeight, (screenBounds.y - 1) + objectHeight);
        transform.position = viewPos;
    }
    private void HandleShootTimer()
    {
        if (!canShoot)
        {
            currentShootGap += Time.deltaTime;
            if(currentShootGap >= SHOOT_INTERVAL)
            {
                currentShootGap = 0;
                canShoot = true;
            }
        }
    }

    private void HandlePlayerInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        isMoving = true;
        if(movement.x == 0 && movement.y == 0) 
        { 
            isMoving = false; 
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0) && canShoot)
        {
            Fire();
        }

        if(canDash && isMoving && Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
    }

    private void HandlePlayerRotation()
    {
        Vector2 aimDirection = mousePos - (Vector2)transform.position;
        Vector2 aimDirectionNormalized = aimDirection.normalized;
        float aimAngle = Mathf.Atan2(aimDirectionNormalized.y, aimDirectionNormalized.x) * Mathf.Rad2Deg - 90f;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, aimAngle);
    }


    private void FixedUpdate()
    {
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
        if (isDashing)
        {
            return;
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void Fire()
    {
        canShoot = false;
        GameObject bulletGO = ObjectPool.SharedInstance.GetPooledObject();
        BulletController bullet = bulletGO.GetComponent<BulletController>();
        if (bulletGO != null)
        {
            bulletGO.transform.position = firePoint.transform.position;
            bulletGO.transform.rotation = firePoint.transform.rotation;
        }
        bullet.Shoot(firePoint.up, fireForce);
    }

    private void Dash()
    {
        StartCoroutine(DashRoutine());
    }

    private IEnumerator DashRoutine()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = movement * dashingPower;
        tr.emitting = true;
        yield return new WaitForSecondsRealtime(dashingTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSecondsRealtime(dashingCooldown);
        canDash = true;
    }
}
