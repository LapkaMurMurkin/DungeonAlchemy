using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FSM : IFSM
{
    public IFSMState CurrentState { get; private set; }
    private readonly Dictionary<Type, IFSMState> _states = new Dictionary<Type, IFSMState>();

    public virtual void InitializeState(IFSMState state)
    {
        if (_states.ContainsKey(state.GetType()))
        {
            Debug.LogError("This condition has already been registered ");
            return;
        }

        _states.Add(state.GetType(), state);
    }

    public virtual void SwitchState<T>() where T : IFSMState
    {
        Type type = typeof(T);

        if (CurrentState?.GetType() == type)
        {
            Debug.LogError("Already in this state.");
            return;
        }

        if (_states.TryGetValue(type, out IFSMState newState))
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
        else
            Debug.LogError("This condition is not registered.");
    }

    public virtual void Update()
    {
        CurrentState?.Update();
    }
}
