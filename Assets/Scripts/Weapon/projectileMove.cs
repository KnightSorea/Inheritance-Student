using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileMove : MonoBehaviour
{
    public float moveSpeed;
    public float damage; // The amount of damage the weapon can deal.
    public float lifeTime;
    public float pierce;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("despawnProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        if(pierce <= 0)
        {
            despawnProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collider belongs to an enemy.
        if (collision.CompareTag("Enemy"))
        {
            // If it does, deal damage to the enemy.
            collision.GetComponent<Enemy>().TakeDamage(damage);
            pierce--;
        }
    }

    void despawnProjectile()
    {
        Destroy(gameObject);
    }
}
