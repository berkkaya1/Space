using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletDamage = 10f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = transform.forward * 5f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Health health = collision.transform.GetComponent<Health>();

        if (health == null) return;

        health.TakeDamage(bulletDamage);
    }
}
