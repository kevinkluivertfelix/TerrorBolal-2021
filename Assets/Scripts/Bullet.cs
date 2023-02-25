using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float spreadFactor;
    public int damage;
    private Rigidbody2D rb;

    void Start()
    {
        Destroy(gameObject, 2f);
        rb = GetComponent<Rigidbody2D>();
        var rot = transform.rotation;
        transform.rotation = rot * Quaternion.Euler(0, 0, Random.Range(-spreadFactor, spreadFactor));
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed * Time.deltaTime;
    }
}
