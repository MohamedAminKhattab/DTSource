using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "SO/Data/PlayerDataSO")]

public class PlayerDataSO : ScriptableObject
{
    public Vector2 position;
    public float speed;
    public float points;
    public float health;
    public float damage;
}
