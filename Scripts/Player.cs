using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speedX = 7f;
    [SerializeField] private float speedY = 3f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform firePointLeft;
    [SerializeField] private Transform firePointRight;
    [SerializeField] private CameraShake cam;
    [SerializeField] private GameObject explosionPrefab;
    private ScoreText score;
    
    [SerializeField] private int maxHealth = 40;
    private int health;
    [SerializeField] private HealthBar healthBar;
    
    private bool firing = false;
    [SerializeField] private float fireRate = 0.4f;
    private float nextFire = 0.0f;

    private int _shotgunActive = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = GameObject.FindWithTag("Score").GetComponent<ScoreText>();
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(dirX * speedX, dirY * speedY);
        
        if (Input.GetButtonDown("Fire1"))
        {
            firing = true;
        }

        if (firing && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            firing = false;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        if (_shotgunActive > 0)
        {
            Instantiate(bulletPrefab, firePointLeft.position, firePointLeft.rotation);
            Instantiate(bulletPrefab, firePointRight.position, firePointRight.rotation);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        cam.Shake(0.2f, 1f);
        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int healPoints)
    {
        health += healPoints;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        healthBar.SetHealth(health);
    }
    
    public void ChangeSpeed(float coefX, float coefY)
    {
        speedX *= coefX;
        speedY *= coefY;
    }

    public void ChangeShotgunActive(int value)
    {
        _shotgunActive += value;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            TakeDamage(enemy.BulletPrefab.GetComponent<Bullet>().Damage);
            enemy.TakeDamage(enemy.MaxHealth);
        }
    }

    void SaveScore()
    {
        PlayerPrefs.SetInt("currentScore", score.Score);
        if (!PlayerPrefs.HasKey("bestScore") || PlayerPrefs.GetInt("bestScore") < score.Score)
        {
            PlayerPrefs.SetInt("bestScore", score.Score);
        }
    }
    
    void Die()
    {
        Debug.Log("Player Died Legally");
        SaveScore();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
