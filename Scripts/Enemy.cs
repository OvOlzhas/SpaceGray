using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Search;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 0.25f;
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private GameObject explosionPrefab;
    
    [SerializeField] private GameObject shotgunPrefab;
    [SerializeField] private GameObject speedPrefab;
    [SerializeField] private GameObject healPrefab;

    [SerializeField] private GameObject missedPrefab;
    
    private ScoreText _score;
    [SerializeField] private int enemyScore = 10;
    
    private int health;
    public int MaxHealth => maxHealth;
    public GameObject BulletPrefab => bulletPrefab;
    private IEnumerator _coroutine;
    void Start()
    {
        rb.velocity = transform.up * -speed;
        health = maxHealth;
        _coroutine = Shooting(fireRate);
        StartCoroutine(_coroutine);
        _score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreText>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            Player player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Player>();
            player.TakeDamage(BulletPrefab.GetComponent<Bullet>().Damage * 3 / 2);
            Instantiate(missedPrefab, transform.position, Quaternion.identity);
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private IEnumerator Shooting(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    void DropBust()
    {
        int random = Random.Range(0, 10);
        if (random == 7)
        {
            Instantiate(healPrefab, transform.position, Quaternion.identity);
        }
        if (random == 8)
        {
            Instantiate(shotgunPrefab, transform.position, Quaternion.identity);
        }
        if (random == 9)
        {
            Instantiate(speedPrefab, transform.position, Quaternion.identity);
        }
    }
    
    void Die()
    {
        _score.IncreaseScore(enemyScore);
        DropBust();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
