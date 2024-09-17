using UnityEngine;

public class bulletSCript : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    public int damage = 10; 

    public GameObject impactVFX;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Health enemyHealth = other.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            Instantiate(impactVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Instantiate(impactVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
