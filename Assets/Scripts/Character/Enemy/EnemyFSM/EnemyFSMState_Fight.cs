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
        _FSM.Model.TargetCharacter.OnDamageDealt += TakeDamage;
        _FSM.AnimatorEvents.OnDamage += SendDamage;

        _FSM.Animator.SetTrigger("Fight");
    }

    public override void Exit()
    {
        _FSM.Model.TargetCharacter.OnDamageDealt -= TakeDamage;
        _FSM.AnimatorEvents.OnDamage -= SendDamage;
    }

    private void SendDamage()
    {
        _FSM.Enemy.OnDamageDealt?.Invoke(_FSM.Model.TargetCharacter, _FSM.Model.AttackDamage.CurrentValue);
    }

    private void TakeDamage(Character character, int damage)
    {
        if (character != _FSM.Enemy)
            return;

        _FSM.Model.CurrentHealth.Value -= damage;
    }
}
