using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFSM : FSM
{
    public Player Player;

    public Animator Animator;

    public InputAction Attack;
    public InputAction Defence;

    public PlayerFSM(Player player)
    {
        Player = player;
        Animator = Player.gameObject.GetComponent<Animator>();

        Attack = ServiceLocator.Get<ActionMap>().Fight.Attack;
        Defence = ServiceLocator.Get<ActionMap>().Fight.Defence;
    }
}
