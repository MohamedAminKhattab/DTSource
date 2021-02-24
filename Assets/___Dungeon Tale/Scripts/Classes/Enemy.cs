using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy:MonoBehaviour
{
    [SerializeField] Vector2 position;
    [SerializeField] int speed;
    [SerializeField] float damage;
    [SerializeField] float health;
    [SerializeField] BoolSO state;
    [SerializeField] EnemyDataSO data;
    [SerializeField] BoolSO detectionstate;
    [SerializeField] Animator enemyanimator;

    public Vector2 Position { get => position; set => position = value; }
    public int Speed { get => speed; set => speed = value; }
    public float Damage { get => damage; set => damage = value; }
    public float Health { get => health; set => health = value; }
    public BoolSO State { get => state; set => state = value; }
    public EnemyDataSO Data { get => data; set => data = value; }
    public BoolSO Detectionstate { get => detectionstate; set => detectionstate = value; }
    public Animator Enemyanimator { get => enemyanimator; set => enemyanimator = value; }

    private void Start()
    {
        Speed = 2;
        Damage = 5.0f;
        Health = 1000.0f;
        Data.speed = Speed;
        Data.health = Health;
        Data.damage = Damage;
        Detectionstate.state = false;
        State.state = true;
    }
    private void Update()
    {
        if (Data.health <=0)
        {
            State.state = false;
        }
        if (State.state==false)
        {
            Enemyanimator.SetFloat("Health", Data.health);
            StartCoroutine(Dying());
        }
    }
    IEnumerator Dying()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}