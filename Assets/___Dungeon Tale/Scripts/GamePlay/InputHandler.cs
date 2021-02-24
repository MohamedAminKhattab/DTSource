using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/DefaultKeyboard")]
public class InputHandler : IInputManager
{
    [SerializeField] KeyCode upCode;
    [SerializeField] KeyCode downCode;
    [SerializeField] KeyCode leftCode;
    [SerializeField] KeyCode rightCode;
    [SerializeField] KeyCode shootCode;
    [SerializeField] KeyCode WaveCode;
    public override bool GetDown()
    {
        return Input.GetKey(downCode);
    }

    public override bool GetLeft()
    {
        return Input.GetKey(leftCode);
    }

    public override bool GetRight()
    {
        return Input.GetKey(rightCode);
    }

    public override bool GetAttack()
    {
        return Input.GetKeyUp(shootCode);
    } 
    public override bool GetWave()
    {
        return Input.GetKeyUp(WaveCode);
    }

    public override bool GetUp()
    {
        return Input.GetKey(upCode);
    }
}
