using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBoost : MonoBehaviour
{
    [SerializeField] private Config config;
    [SerializeField] private float duration = 3f;
    private BoostActivate _boostActivate;
    private Rigidbody2D _rb;

    private IEnumerator _coroutine;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up * -config.boostSpeed;
        _boostActivate = GameObject.FindGameObjectWithTag("Player").GetComponent<BoostActivate>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _boostActivate.ShotgunBoost(duration);
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
