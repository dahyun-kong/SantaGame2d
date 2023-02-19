using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float speed,damage;

    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
        Invoke("DestroyBullet", 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.y == 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        }

    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<Enemy>().TakeDamage(damage);
                Destroy(gameObject);
            }
    
        
        if (collision.CompareTag("Player1"))
        {
            Destroy(gameObject);
            collision.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}

