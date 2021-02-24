using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCharacterMovement : MonoBehaviour
{

    public Vector2SO movement;
    public PlayerDataSO playerData;
    Rigidbody2D body;
    BoolSO isWalking;
    Animator playerAnim;
    void Start()
    {

        movement.vector = Vector2.zero;
        body = GetComponent<Rigidbody2D>();
        playerData.position = this.transform.position;
        playerAnim = GetComponent<Animator>();
    }
     void Update()
    {
        if (Mathf.Clamp01(body.velocity.magnitude)>0)
            playerAnim.SetBool("Walking", true);
        else
            playerAnim.SetBool("Walking", false);
    }
    private void FixedUpdate()
    {
        body.SetRotation(Mathf.Atan2(movement.vector.x, -movement.vector.y) * Mathf.Rad2Deg);
        body.velocity = movement.vector * playerData.speed;
        playerData.position = this.transform.position;

    }
}
