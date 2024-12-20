using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState : IFSMState
{
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}
