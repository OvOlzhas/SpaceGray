using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBoost : MonoBehaviour
{
    [SerializeField] private Config config;
    private Player _player;
    private Rigidbody2D _rb;

    private IEnumerator _coroutine;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up * -config.boostSpeed;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _player.Heal(config.healPoints);
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("DownBurder"))
        {
            Destroy(gameObject);
        }
    }
}
