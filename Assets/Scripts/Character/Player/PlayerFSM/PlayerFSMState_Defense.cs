using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_Defense : PlayerFSMState
{
    public PlayerFSMState_Defense(PlayerFSM FSM) : base(FSM) { }

    private float _duration = 0.3f;

    public override void Enter()
    {
        _FSM.AnimatorEvents.OnShieldDown += ShieldDown;
        _FSM.Player.StartCoroutine(DefenseTime(_duration));
    }

    public override void Exit()
    {
        _FSM.AnimatorEvents.OnShieldDown -= ShieldDown;
    }

    IEnumerator DefenseTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        _FSM.Animator.SetTrigger("ShieldDown");
    }

    private void ShieldDown()
    {
        _FSM.SwitchState<PlayerFSMState_ShieldDown>();
    }
}
