using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_Defense : PlayerFSMState
{
    public PlayerFSMState_Defense(PlayerFSM FSM) : base(FSM) { }

    private float _duration = 0.3f;

    public override void Enter()
    {
        _FSM.Player.OnDamageReceive += Block;
        _FSM.AnimatorEvents.OnShieldDown += ShieldDown;
        _FSM.Player.StartCoroutine(DefenseTime(_duration));
    }

    public override void Exit()
    {
        _FSM.Player.OnDamageReceive -= Block;
        _FSM.AnimatorEvents.OnShieldDown -= ShieldDown;
    }

    IEnumerator DefenseTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        _FSM.Animator.SetTrigger("ShieldDown");
    }

    private void Block(int damage)
    {
        _FSM.Animator.Play("Block");
        _FSM.Player.BlockSound.Play();
    }

    private void ShieldDown()
    {
        _FSM.Animator.ResetTrigger("ShieldDown");
        _FSM.SwitchState<PlayerFSMState_ShieldDown>();
    }
}
