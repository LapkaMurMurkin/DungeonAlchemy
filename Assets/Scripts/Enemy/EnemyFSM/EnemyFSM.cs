using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : FSM
{
    public Enemy Enemy;
    public EnemyModel EnemyModel;
    public EnemyView EnemyView;

    public Animator Animator;

    public List<Tile> Road;
    public int PositionOnRoad;

    public EnemyFSM(Enemy enemy, EnemyModel enemyModel, EnemyView enemyView)
    {
        Enemy = enemy;
        EnemyModel = enemyModel;
        EnemyView = enemyView;

        Animator = Enemy.gameObject.GetComponent<Animator>();

        Road = ServiceLocator.Get<Road>().Tiles;
        PositionOnRoad = Road.FindIndex(tile => tile.Enemy == Enemy);
    }
}
