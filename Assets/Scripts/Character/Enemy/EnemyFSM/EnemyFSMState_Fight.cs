using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class EnemyFSMState_Fight : EnemyFSMState
{
    public EnemyFSMState_Fight(EnemyFSM FSM) : base(FSM) { }


    public override void Enter()
    {
        _FSM.Model.TargetCharacter.OnDeath += Exit;
        _FSM.AnimatorEvents.OnDamage += SendDamage;

        _FSM.Animator.SetTrigger("Fight");
    }

    public override void Exit()
    {
        _FSM.Model.TargetCharacter.OnDeath -= Exit;
        _FSM.AnimatorEvents.OnDamage -= SendDamage;
    }

    private void SendDamage()
    {
        _FSM.Enemy.TargetCharacter.TakeDamage(_FSM.Enemy.AttackDamage.CurrentValue);
    }
}
