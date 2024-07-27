using System.Collections;
using System.Collections.Generic;
using R3;
using R3.Triggers;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFSM : FSM
{
    public Player Player;
    public PlayerModel PlayerModel;
    public List<Tile> Road;
    public int PlayerPosition;

    public Animator Animator;

    public InputAction Attack;
    public InputAction Defence;

    public float AttackTime;
    public float ShieldUpTime;
    public float ShieldDownTime;
    public float IdleTime;

    public PlayerFSM(Player player, PlayerModel playerModel)
    {
        Player = player;
        PlayerModel = playerModel;
        Road = ServiceLocator.Get<Road>().Tiles;
        PlayerPosition = Road.FindIndex(tile => tile.Player == Player);
        Animator = Player.gameObject.GetComponent<Animator>();

        Attack = ServiceLocator.Get<ActionMap>().Fight.Attack;
        Defence = ServiceLocator.Get<ActionMap>().Fight.Defence;

        AnimationClip[] clips = Animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "Attack":
                    AttackTime = clip.length;
                    break;
                case "ShieldUp":
                    ShieldUpTime = clip.length;
                    break;
                case "ShieldDown":
                    ShieldDownTime = clip.length;
                    break;
                case "Idle":
                    IdleTime = clip.length;
                    break;
            }
        }
    }
}
