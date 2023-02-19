using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float MaxHP = 2;
    float currentHP;
    SpriteRenderer SR;
    [SerializeField] GameObject[] explosionObj;
    [SerializeField]
    float cooltime;
    float curtime;
    [SerializeField] GameObject snowball;
    [SerializeField] Transform ballPosition;

    private void Awake()
    {
        currentHP = MaxHP;
        SR = GetComponent<SpriteRenderer>();
        curtime = cooltime;
    }

    private void Update()
    {
        curtime -= Time.deltaTime;

        if (curtime >= 0)
        { Instantiate(snowball, ballPosition.position, transform.rotation); curtime = cooltime; }
    }
    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        StopCoroutine("HitcolorAnimation");
        StartCoroutine("HitcolorAnimation");

        if (currentHP <= 0)
        {
            Ondie();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            Destroy(gameObject);

        }
    }

    IEnumerator HitcolorAnimation()
    {
        SR.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        SR.color = Color.white;
    }

    public void Ondie()
    {
        SpawnItem();
        Destroy(gameObject);
    }

    private void SpawnItem()
    {
        int spawnItem = Random.Range(0, 100);
        if (spawnItem < 10)
        { Instantiate(explosionObj[0], transform.position, Quaternion.identity); }
    }
}
