using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player = null;
    public float speed = 2f;
    private float distance;
    private bool flip;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        FacePlayer();
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void FacePlayer()
    {
        Vector3 scale = transform.localScale;
        if (player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
        }
        transform.localScale = scale;
    }
}
