using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySceneLoader : MonoBehaviour
{
    public static ServiceLocator ServiceLocator = new ServiceLocator();

    private ActionMap _actionMap;

    private Player _player;
    private PlayerCamera _playerCamera;

    private Enemy _enemy;

    private void Awake()
    {
        ServiceLocator = new ServiceLocator();

        _actionMap = new ActionMap();
        _actionMap.Enable();
        ServiceLocator.Register<ActionMap>(_actionMap);

        _player = FindObjectOfType<Player>();
        _player.Initialize();
        ServiceLocator.Register<Player>(_player);

        _playerCamera = FindObjectOfType<PlayerCamera>();
        ServiceLocator.Register<PlayerCamera>(_playerCamera);

        _enemy = FindObjectOfType<Enemy>();
        _enemy.Initialize();
    }
}

