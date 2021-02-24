using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField] EnemyDataSO data;
    [SerializeField] BoolSO isdetecting;
    [SerializeField] Image enemyhb;
    [SerializeField] Text enemyhealthvalue;
    private void Update()
    {
        if (isdetecting.state == true)
        {
            ///Hager ->TODO:: show enemy health slider and change fill amount
        }
    }
}