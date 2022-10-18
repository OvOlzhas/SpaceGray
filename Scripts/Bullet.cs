using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CircleCollider2D coll;
    [SerializeField] private int damage = 10;
    [SerializeField] private bool fromPlayer;
    [SerializeField] private float lifeExpectancy = 7;
    
    public int Damage => damage;

    private IEnumerator _coroutine;
    void Start()
    {
        rb.velocity = transform.up * -speed;
        _coroutine = WaitAndDeath(lifeExpectancy);
        StartCoroutine(_coroutine);
    }

    private IEnumerator WaitAndDeath(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Enemy") && fromPlayer)
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (hitInfo.name == "Player" && !fromPlayer)
        {
            Player enemy = hitInfo.GetComponent<Player>();
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
