using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] PlayerDataSO playerData;
    [SerializeField]EnemyDataSO[] attackingenemy;

    [SerializeField] BoolSO playerState; //Dead or alive

    public void Update()
    {
        if (playerData.health <= 0)
        {
            playerState.state = false;
            //End Game
        }
    }
}
