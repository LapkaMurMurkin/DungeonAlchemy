using System.Collections;
using System.Collections.Generic;
using R3;
using R3.Triggers;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFSM : FSM
{
    public Player Player;
    public PlayerModel Model;

    public Animator Animator;
    public AnimatorEvents AnimatorEvents;

    public InputAction Attack;
    public InputAction Defence;

    public PlayerFSM(Player player, PlayerModel playerModel)
    {
        Player = player;
        Model = playerModel;

        Animator = Player.GetComponent<Animator>();
        AnimatorEvents = Player.GetComponent<AnimatorEvents>();

        Attack = ServiceLocator.Get<ActionMap>().Fight.Attack;
        Defence = ServiceLocator.Get<ActionMap>().Fight.Defence;
    }
}
