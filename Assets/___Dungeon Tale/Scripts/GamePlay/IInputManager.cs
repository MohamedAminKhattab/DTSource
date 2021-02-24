using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IInputManager : ScriptableObject
{
    public abstract bool GetUp();
    public abstract bool GetDown();
    public abstract bool GetLeft();
    public abstract bool GetRight();
    public abstract bool GetAttack();
    public abstract bool GetWave();
}
