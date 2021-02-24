using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyPatrolAI : MonoBehaviour
{

    private bool down = true;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2SO enemymovement;
    [SerializeField] EnemyDataSO enemyData;

     void Start()
    {
        enemyData.position = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = -transform.up * enemyData.speed;
        enemymovement.vector = transform.position;
        enemyData.position =transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider)
        {
            if (collision.collider.CompareTag("Wall"))
            {
                var contacts = collision.contacts;
                for (int i = 0; i < contacts.Length; i++)
                {
                    if (down)
                    {
                        if(contacts[i].normal==Vector2.up)
                        transform.up = Vector2.down;
                        down = false;
                    }
                    else
                    {
                        if (contacts[i].normal == Vector2.down)
                            transform.up = Vector2.up;
                        down = true;
                    }
                }
            }
        }
    }
}