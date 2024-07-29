using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_DefaultAttack : PlayerFSMState
{
    public PlayerFSMState_DefaultAttack(PlayerFSM FSM) : base(FSM) { }

    public override void Enter()
    {
        _FSM.AnimatorEvents.OnDamage += SendDamage;
        _FSM.AnimatorEvents.OnAnimationEnd += EndAttack;
        _FSM.Animator.SetTrigger("Attack");
    }

    public override void Exit()
    {
        _FSM.AnimatorEvents.OnDamage -= SendDamage;
        _FSM.AnimatorEvents.OnAnimationEnd -= EndAttack;
    }

    private void SendDamage()
    {
        _FSM.Model.TargetCharacter.TakeDamage(_FSM.Player.AttackDamage.CurrentValue);
    }

    private void EndAttack()
    {
        _FSM.SwitchState<PlayerFSMState_Fight>();
    }
}
