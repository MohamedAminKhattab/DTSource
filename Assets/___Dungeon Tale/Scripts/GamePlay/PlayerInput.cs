using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 added boolean scriptable object boolso to insure player can't start a wave with in a wave
this doesn't generate new line renderer points but expanda the visible area around the player which is expanded during the wave
 */
public class PlayerInput : MonoBehaviour
{
    public IInputManager inputManager;
    public Vector2SO movement;
    [SerializeField] BoolSO wave;
    [SerializeField] PlayerAttack playerAttack;
    //serialied filed for player attack and drag and drop GO w/ player attack script in editor

    [SerializeField] DetectionWave detectionWave;
    [SerializeField] Button detectionButton;
    bool clicked = false;
    // Use this for initialization
    void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
        if (null == inputManager)
            inputManager = new InputHandler();
        detectionButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()

    {

        Vector2 movement = Vector2.zero;

        if (inputManager.GetUp())
        {
            movement.y++;
        }

        if (inputManager.GetDown())
        {
            movement.y--;
        }

        if (inputManager.GetLeft())
        {
            movement.x--;
        }

        if (inputManager.GetRight())
        {
            movement.x++;
        }

        if (inputManager.GetAttack())
        {
    
            playerAttack.IsAttackingEnemy();
        }

        if (inputManager.GetWave() && wave.state == false)
        {
            if (clicked)
                detectionWave.IsActiveWave();
        }

        this.movement.vector = movement;
    }
    void TaskOnClick()
    {
        clicked = true;
    }
}

