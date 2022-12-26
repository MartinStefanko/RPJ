using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    public float damage=1;

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Void":
                Destroy(gameObject);
                break;
            case "Enemy":
                Destroy(gameObject);
                break;
        }
         
    }
    private void OnCollisionEnter2D(Collision2D collision)
        {
        if (collision.gameObject.GetComponent<HealthSystemMeleeEnemy>() != null)
        {
            HealthSystemMeleeEnemy _healthSystem = collision.gameObject.GetComponent<HealthSystemMeleeEnemy>();
            _healthSystem.TakeDamage(damage);
        }
        Destroy(gameObject);
        }

}
