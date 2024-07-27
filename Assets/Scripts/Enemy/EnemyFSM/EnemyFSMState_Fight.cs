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
        _FSM.Animator.SetTrigger("Fight");
        _FSM.EnemyView.Initialize(_FSM.Enemy);
        _FSM.EnemyView.Show();
    }

    public override void Exit()
    {

    }

    public override void Update()
    {

    }
}
