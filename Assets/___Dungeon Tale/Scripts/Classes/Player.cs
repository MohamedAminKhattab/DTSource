using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Vector2 position;
    [SerializeField] float speed;
    [SerializeField] float points;
    [SerializeField] float health;
    [SerializeField] float damage;
    [SerializeField] PlayerDataSO data;
    

    private void Start()
    {
        speed = 2.5f;
        points = 0.0f;
        health = 1000.0f;
        damage = 200.0f;
        data.speed = speed;
        data.points = points;
        data.health = health;
        data.damage = damage;
    }

    private void Update()
    {
        if (data.health <= 0)
            this.gameObject.SetActive(false);
    }

}
