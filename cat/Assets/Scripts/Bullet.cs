using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(0f, 50f)] [SerializeField] private float speed = 20f;
    [SerializeField] private Rigidbody2D rb;

    private float lastTimeShoot; 
    private float flyTime = 2f;

    private void Start()
    {
        rb.velocity = transform.right * speed;
        lastTimeShoot = Time.time;
    }

    private void Update()
    {
       if(lastTimeShoot + flyTime < Time.time)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "hittable")
        {
            Debug.Log("hit");
        }
        Destroy(gameObject);
    }
}
