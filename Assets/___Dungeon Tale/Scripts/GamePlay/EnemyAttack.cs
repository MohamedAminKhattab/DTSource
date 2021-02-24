using System;
using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] EnemyDataSO enemydata;
    [SerializeField] PlayerDataSO playerdata;
    [SerializeField] BoolSO isdetecting;
    [SerializeField] Animator enemyanimator;
    [SerializeField] BoolSO EndGame;

    public void FixedUpdate()
    {
        if (isdetecting.state == true)
        {
            if (Mathf.Abs((enemydata.position - playerdata.position).magnitude) < 2.5 && enemydata.health > 0)
            {
                //Debug.Log(playerdata.name + "||" + Mathf.Abs((enemydata.position - playerdata.position).magnitude));
                this.gameObject.layer = 8;
                enemyanimator.SetBool("Attacking", true);
                playerdata.health -= enemydata.damage;
                StartCoroutine(EnemyAttackWait());
            }
            if (playerdata.health < 0)
            {
                EndGame.state = true;
            }
        }
    }

    IEnumerator EnemyAttackWait()
    {
        yield return new WaitForSeconds(1);
    }
}