using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowAI : MonoBehaviour
{
    [SerializeField] BoolSO isdetecting;
    [SerializeField] float ray_distance = 2.0f;
    [SerializeField] Transform playerDetection;
    [SerializeField] EnemyDataSO data;
    [SerializeField] Animator enemyanimator;
    private void Start()
    {
        enemyanimator = GetComponent<Animator>();
    }
    void Update()
    {
       
        Collider2D[] player = Physics2D.OverlapCircleAll(playerDetection.position,ray_distance);
        foreach (var item in player)
        {

                if (item.CompareTag("Player"))
                {
                    Vector3 direction = item.transform.position - transform.position;
                    transform.up = -direction.normalized;
                    isdetecting.state = true;
                }
                else
                {
                    isdetecting.state = false;
                }
            
                data.position = transform.position;
                enemyanimator.SetBool("Attacking", isdetecting.state);
        }

    }
}