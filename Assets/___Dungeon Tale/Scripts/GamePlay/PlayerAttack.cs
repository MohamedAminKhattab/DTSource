using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{//update for hager

    [SerializeField] PlayerDataSO data;
    [SerializeField] EnemyDataSO targetenemy;
    [SerializeField] EnemyDataSO[] enemydata;
    private float gaindPointes;
    Animator playeranimator;
    bool attacking;

    private void Start()
    {
        playeranimator = GetComponent<Animator>();
        attacking = false;
    }


    public void IsAttackingEnemy()
    {
        for (int i = 0; i < enemydata.Length; i++)
        {
        if (Mathf.Abs((enemydata[i].position - data.position).magnitude) < 2.5 && enemydata[i].health > 0)
        {
            attacking = true;
            targetenemy = enemydata[i];
        }
        else
        {
            attacking = false;
        }
        EnemyAttacked();
        }

    }
    public void EnemyAttacked()
    {
        if (attacking)
        {
            targetenemy.health -= data.damage;
            //gain points
            gaindPointes = targetenemy.damage;
            data.points += gaindPointes;
            playeranimator.SetBool("Attack", true);
        }
        else
        {
            playeranimator.SetBool("Attack", false);

        }
    }
}
