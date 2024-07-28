using System.Collections;
using System.Collections.Generic;
using R3;
using R3.Triggers;
using UnityEngine;

public class EnemyFSM : FSM
{
    public Enemy Enemy;
    public EnemyModel Model;
    public EnemyView View;

    public Animator Animator;
    public AnimatorEvents AnimatorEvents;

    public List<Tile> Road;
    public int PositionOnRoad;

    public EnemyFSM(Enemy enemy, EnemyModel enemyModel, EnemyView enemyView)
    {
        Enemy = enemy;
        Model = enemyModel;
        View = enemyView;

        Animator = Enemy.gameObject.GetComponent<Animator>();
        AnimatorEvents = Enemy.GetComponent<AnimatorEvents>();

        Road = ServiceLocator.Get<Road>().Tiles;
        PositionOnRoad = Road.FindIndex(tile => tile.Character == Enemy);

        Model.CurrentHealth.Subscribe(value =>
        {
            if (value <= 0)
                Enemy.Destroy(Enemy.gameObject);

        }).AddTo(Enemy);
    }
}
