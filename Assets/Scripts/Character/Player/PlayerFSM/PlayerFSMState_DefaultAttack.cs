using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PlayerFSMState_DefaultAttack : PlayerFSMState
{
    public PlayerFSMState_DefaultAttack(PlayerFSM FSM) : base(FSM) { }

    public override void Enter()
    {
        _FSM.Player.AttackSound.Play();
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

        if (_FSM.Model.TargetCharacter.CurrentHealth.CurrentValue <= 0)
        {
            List<Slot> ingredients = _FSM.Player.Inventory.Storage.Slots.ToList();

            foreach (Slot ingredient in ingredients)
            {
                if (ingredient.Item.Value.name.Equals("Ingredient 1"))
                    ingredient.Quantity.Value += 4;

                if (ingredient.Item.Value.name.Equals("Ingredient 2"))
                    ingredient.Quantity.Value += 2;

                if (ingredient.Item.Value.name.Equals("Ingredient 3"))
                    ingredient.Quantity.Value += 1;
            }
        }
    }

    private void EndAttack()
    {
        _FSM.SwitchState<PlayerFSMState_Fight>();
    }
}
