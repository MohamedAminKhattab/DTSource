using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataSO", menuName = "SO/Data/EnemyDataSO")]
public class EnemyDataSO : ScriptableObject
    {
    public Vector2 position;
    public int speed;
    public float damage;
    public float health;
   }