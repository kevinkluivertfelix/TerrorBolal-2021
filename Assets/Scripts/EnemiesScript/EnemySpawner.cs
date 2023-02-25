using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    public ObjectPool<Enemy> _pool;
    public Enemy[] enemyTest;
    GameObject eSP;

    private void Start()
    {
        eSP = new GameObject("EnemySpawnPool");
        _pool = new ObjectPool<Enemy>(CreateEnemies, OnSpawning, OnDispawning, OnDestroyEnemy, true, 100, 1000);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _pool.Get();
        }
    }
    private Enemy CreateEnemies()
    {
        Enemy enemy = Instantiate(enemyTest[Random.Range(0, enemyTest.Length)], eSP.transform);
        enemy.SetPool(_pool);

        return enemy;
    }

    private void OnSpawning(Enemy enemy)
    {
        enemy.transform.position = new Vector2(gameObject.transform.position.x, Random.Range(-3.5f, 3.5f));

        enemy.gameObject.SetActive(true);
    }

    private void OnDispawning(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private void OnDestroyEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }
}
