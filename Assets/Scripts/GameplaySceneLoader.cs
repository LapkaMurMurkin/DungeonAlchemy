using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySceneLoader : MonoBehaviour
{
    public static ServiceLocator ServiceLocator = new ServiceLocator();

    private ActionMap _actionMap;

    private Road _road;

    private Player _player;
    private PlayerCamera _playerCamera;

    private Enemy[] _enemys;

    private void Awake()
    {
        ServiceLocator = new ServiceLocator();

        _actionMap = new ActionMap();
        _actionMap.Enable();
        ServiceLocator.Register<ActionMap>(_actionMap);

        _road = FindObjectOfType<Road>();
        _road.Initialize();
        ServiceLocator.Register<Road>(_road);

        _enemys = FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in _enemys)
            enemy.Initialize();

        _player = FindObjectOfType<Player>();
        _player.Initialize();
        ServiceLocator.Register<Player>(_player);

        _playerCamera = FindObjectOfType<PlayerCamera>();
        ServiceLocator.Register<PlayerCamera>(_playerCamera);
    }
}

