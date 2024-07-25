using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFSM
{
    public abstract void InitializeState(IFSMState state);

    public abstract void SwitchState<T>() where T : IFSMState;

    public abstract void Update();
}
