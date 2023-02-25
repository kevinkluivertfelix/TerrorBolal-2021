using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int enemyHealth;
    [SerializeField] private float enemySpeed;
    [SerializeField] private int enemyDamage;

    private ObjectPool<Enemy> _pool;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = -transform.right * enemySpeed * Time.deltaTime;
    }

    public void SetPool(ObjectPool<Enemy> pool)
    {
        _pool = pool;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            _pool.Release(this);
        }
    }
}
