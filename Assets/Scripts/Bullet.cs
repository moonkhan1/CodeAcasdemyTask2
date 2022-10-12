using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float BulletForce = 5f;
    [SerializeField] int BulletDamage = 5;
    PlayerController _player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * BulletForce;
        StartCoroutine(SpawnAndKillBullet());
        
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Target"))
        {
            Debug.Log(other.transform.name);
            other.transform.GetComponent<ObjectController>().GetDamage(BulletDamage);
            Destroy(gameObject);
        }
        if (other.transform.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SpawnAndKillBullet()
    {
        
        
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}